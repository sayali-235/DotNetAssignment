using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;
using TicketBookingApp.Infrastructure.Context;

namespace TicketBookingApp.Infrastructure.Repository
{
    public class BookingRepository : IBookingRepository
    {
        readonly TicketBookingDbContext _ticketBookingDbContext;
        public BookingRepository(TicketBookingDbContext ticketBookingDbContext)
        {
            _ticketBookingDbContext= ticketBookingDbContext;
        }

        public async Task<Booking> BookTicket(int userId, int eventId, int seatNumber)
        {
            var booking = new Booking
            {
                UserId = userId,
                EventId = eventId,
                SeatNumber = seatNumber,
                BookingDate = DateTime.Now
            };
         var result=   await _ticketBookingDbContext.Bookings.AddAsync(booking);
            await _ticketBookingDbContext.SaveChangesAsync();
            return result.Entity;// Ensure you return the tracked entity
        }

        public async Task<bool> CancelBooking(int bookingId)
        {
          
            var booking = await GetBookingById(bookingId);
            if(booking is not null)
            {
                _ticketBookingDbContext.Remove(booking);
              return   await _ticketBookingDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
             return await _ticketBookingDbContext.Bookings
                .Include(e=>e.Event)
                .Include(u=>u.User)
                .ToListAsync();
        }

        public async Task <Booking> GetBookingById(int bookingId)
        { 
            return await _ticketBookingDbContext.Bookings.FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }
    }
}
