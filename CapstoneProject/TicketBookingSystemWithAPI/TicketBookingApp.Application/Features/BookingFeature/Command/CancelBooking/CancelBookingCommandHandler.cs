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
        readonly IEventRepository _eventRepository;
        public CancelBookingCommandHandler(IBookingRepository bookingRepository, IEventRepository eventRepository)
        {
            _bookingRepository = bookingRepository;
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetBookingById(request.bookingId);
            if (booking == null)
            {
                throw new NotFoundException($"Booking with id {request.bookingId} not found");
            }

            var eventDetails = await _eventRepository.GetEventByIdAsync(booking.EventId);
            if (eventDetails == null)
            {
                throw new NotFoundException($"Event with ID {booking.EventId} not found");
            }

          
            await _eventRepository.UpdateEventAsync(eventDetails);

            return await _bookingRepository.CancelBooking(booking.BookingId);
        }
    }
}
