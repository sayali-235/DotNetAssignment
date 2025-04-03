using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.BookingFeature.Command.UpdateBooking
{
    public record UpdateBookingCommand(int userId, int bookingId, int? newEventId, List<int>? newSeatNumbers):IRequest<Booking>;
    
}
