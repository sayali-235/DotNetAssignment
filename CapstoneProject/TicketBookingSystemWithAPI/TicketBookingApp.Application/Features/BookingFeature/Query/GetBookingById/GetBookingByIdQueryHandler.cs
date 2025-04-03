using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Features.EventFeature.Query.GetEventById;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.BookingFeature.Query.GetBookingByUserId
{
    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery,  Booking>
    {
        readonly IBookingRepository _bookingRepository;
        public GetBookingByIdQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
          
            var bookingFindStatus = await _bookingRepository.GetBookingById(request.bookingId);
            return bookingFindStatus;
        }
    }
}
