using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketBookingApp.Domain;
using TicketBookingApp.Infrastructure.Configuration;

namespace TicketBookingApp.Infrastructure.Context
{
    public class TicketBookingDbContext:DbContext
    {
        public TicketBookingDbContext(DbContextOptions<TicketBookingDbContext>options):base(options)  
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AuthorConfiguration)
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            //modelBuilder.ApplyConfiguration(new BookingConfiguration());
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Event> Events { get; set; }
        //public DbSet<Booking> Bookings { get; set; }
    }
}
