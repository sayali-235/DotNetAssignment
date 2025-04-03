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
    public class TicketBookingDbContext : DbContext
    {
        public TicketBookingDbContext(DbContextOptions<TicketBookingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());

            modelBuilder.Entity<Event>()
                .Property(e => e.EventType)
                .HasConversion<string>();

            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingStatus)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentStatus)
                .HasConversion<string>();



            modelBuilder.Entity<Payment>()
            .HasOne(p => p.Booking)
            .WithOne(b => b.Payment)
            .HasForeignKey<Payment>(p => p.BookingId)
            .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Booking)
            //    .WithOne(b => b.User)
            //    .HasForeignKey(b => b.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
               .HasOne(b => b.Event)
               .WithMany(e => e.Booking)
               .HasForeignKey(b => b.EventId)
               .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
