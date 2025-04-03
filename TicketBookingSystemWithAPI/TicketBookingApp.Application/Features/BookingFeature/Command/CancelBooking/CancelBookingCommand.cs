using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TicketBookingApp.Application.Features.BookingFeature.Command.CancelBooking
{
    public record CancelBookingCommand(int bookingId):IRequest<bool>;
   
}
