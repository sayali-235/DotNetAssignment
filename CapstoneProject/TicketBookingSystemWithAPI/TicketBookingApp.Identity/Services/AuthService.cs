using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TicketBookingApp.Application.Exceptions;
using TicketBookingApp.Application.Interfaces.Identity;
using TicketBookingApp.Application.Models.Identity;
using TicketBookingApp.Domain;
using TicketBookingApp.Identity.Context;
using TicketBookingApp.Identity.Model;
using TicketBookingApp.Identity.Model.Constants;
using TicketBookingApp.Infrastructure.Context;

namespace TicketBookingApp.Identity.Services
{
    public class AuthService : IAuthService
    {
    
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly JwtSettings _jwtSettings;
        readonly TicketBookingDbContext _ticketBookingDbContext;
        
        public AuthService(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager,IOptions<JwtSettings> jwtSettings,TicketBookingDbContext ticketBookingDbContext )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings=jwtSettings.Value;
            _ticketBookingDbContext=ticketBookingDbContext;
           
        }
        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user=await _userManager.FindByEmailAsync(authRequest.Email);
            if (user == null)
            {
                throw new NotFoundException($"user with Email{authRequest.Email} not exists");
            }
            var userPassword=await _signInManager.CheckPasswordSignInAsync(user, authRequest.Password, false);
            if(userPassword.Succeeded== false)
            {
                throw new BadRequestException($"Password credentials are wrong");
            }
            JwtSecurityToken jwtSecurityToken = await  GenerateToken(user);
            var response = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
            return response;
        }

        private async Task <JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            //get user information from Db
            var userClaims= await _userManager.GetClaimsAsync(user);
            //List of roles user belongs to
            var roles=await _userManager.GetRolesAsync(user);
            //Convert roles list into claims
            //new claim(claimtype.role,'admin')
            var roleClaims = roles.Select(roles => new Claim(ClaimTypes.Role, roles)).ToList();
            //create claim
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid:",user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials

                );
            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            var user = new ApplicationUser
            {
                FirstName=registrationRequest.FirstName,
                LastName=registrationRequest.LastName,
                UserName=registrationRequest.Username,
                Email = registrationRequest.Email,
                PhoneNumber=registrationRequest.PhoneNo,
                EmailConfirmed=true 
            };
           var result= await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                
               await _userManager.AddToRoleAsync(user, Roles.User);
                var customer = new User
                {
                    UserName= registrationRequest.Username,
                    Email=registrationRequest.Email, 
                    PhoneNumber=registrationRequest.PhoneNo,
                    ApplicationUserId = user.Id
                };
                await  _ticketBookingDbContext.Users.AddAsync(customer);
              await _ticketBookingDbContext.SaveChangesAsync();
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
               var errorResult= result.Errors.Select(e => e.Description).ToList();
                throw new BadRequestException($"{string.Join(',',errorResult)}");
            }
        }
    }
}
