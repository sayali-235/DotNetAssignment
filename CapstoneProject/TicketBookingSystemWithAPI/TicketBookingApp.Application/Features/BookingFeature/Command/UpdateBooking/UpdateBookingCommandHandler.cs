using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.BookingFeature.Command.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Booking>
    {
        readonly IBookingRepository _bookingRepository;
        public UpdateBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<Booking> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.UpdateBooking(
                request.userId,
                request.bookingId,
                request.newEventId,
                request.newSeatNumbers
                );
        }
    }
}
