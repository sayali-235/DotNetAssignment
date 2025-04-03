using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.BookingFeature.Command.BookTicket
{
    public record BookTicketCommand(int userId,int eventId,int seatNumber):IRequest<int>;
     
}
