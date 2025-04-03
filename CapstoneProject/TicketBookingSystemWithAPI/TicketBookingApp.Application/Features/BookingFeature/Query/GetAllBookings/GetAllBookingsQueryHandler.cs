using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.BookingFeature.Query.GetAllBookings
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, IEnumerable<Booking>>
    {
        readonly IBookingRepository _bookingRepository;
        public GetAllBookingsQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var allBookings=await _bookingRepository.GetAllBookings();
            return allBookings;
        }
    }
}
