using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TicketBookingApp.Application.Features.BookingFeature.Query.ShowAvailableSeats
{
    public record ShowAvailableSeatsQuery(int eventId):IRequest<IEnumerable<int>>;
    
}
