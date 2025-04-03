using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Interfaces;

namespace TicketBookingApp.Application.Features.BookingFeature.Query.ShowAvailableSeats
{
    public class ShowAvailableSeatsQueryHandler : IRequestHandler<ShowAvailableSeatsQuery, IEnumerable<int>>
    {
        readonly IBookingRepository _bookingRepository;
        public ShowAvailableSeatsQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<IEnumerable<int>> Handle(ShowAvailableSeatsQuery request, CancellationToken cancellationToken)
        {
           var availableSeats= await _bookingRepository.ShowAvailableSeats(request.eventId);
            return availableSeats;
        }
    }
}
