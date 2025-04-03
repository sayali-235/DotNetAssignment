using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking> BookTicket(int userId,int eventId,int seatNumber);
        Task <Booking> GetBookingById(int bookingId);
        Task<bool> CancelBooking(int bookingId);
       

    }
}
