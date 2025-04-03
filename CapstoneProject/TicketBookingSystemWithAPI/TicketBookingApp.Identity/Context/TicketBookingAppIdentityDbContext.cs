using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketBookingApp.Identity.Configuration;

namespace TicketBookingApp.Identity.Context
{
    public class TicketBookingAppIdentityDbContext:IdentityDbContext
    {
        public TicketBookingAppIdentityDbContext(DbContextOptions<TicketBookingAppIdentityDbContext>options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
