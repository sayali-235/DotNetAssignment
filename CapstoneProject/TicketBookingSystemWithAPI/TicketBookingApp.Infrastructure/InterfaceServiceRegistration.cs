using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Infrastructure.Context;
using TicketBookingApp.Infrastructure.Repository;

namespace TicketBookingApp.Infrastructure
{
    public static class InterfaceServiceRegistration
    {
       public static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketBookingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TicketBookingAPIConString"));

            });
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
 
            return services;
        } 


    }
}   
