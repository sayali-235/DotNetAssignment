using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Exceptions;
using TicketBookingApp.Application.Interfaces;

namespace TicketBookingApp.Application.Features.BookingFeature.Command.CancelBooking
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, bool>
    {
        readonly IBookingRepository _bookingRepository;
        public CancelBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<bool> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        { 
            var bookingFindStatus = await _bookingRepository.GetBookingById(request.bookingId);
            if (bookingFindStatus is null)
            {
                throw new NotFoundException($"Booking with this id ::{request.bookingId} not found");
            }
            return await _bookingRepository.CancelBooking(bookingFindStatus.BookingId);
        }
    }
}
