using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.BookingFeature.Command.BookTicket
{
    public class BookTicketCommandHandler : IRequestHandler<BookTicketCommand, int>
    {
        readonly IBookingRepository _bookingRepository;
        readonly IEventRepository _eventRepository;
        public BookTicketCommandHandler(IBookingRepository bookingRepository, IEventRepository eventRepository)
        {
            _bookingRepository = bookingRepository;
            _eventRepository = eventRepository;
        }
        public async Task<int> Handle(BookTicketCommand request, CancellationToken cancellationToken)
        {
            var eventDetails = await _eventRepository.GetEventByIdAsync(request.eventId);
            if (eventDetails == null)
            {
                throw new Exception("Event Not Found");
            }
            if (eventDetails.AvailableSeats < request.seatNumbers.Count)
            {
                throw new Exception("Not enough available seats");
            }
            var booking = await _bookingRepository.BookTicket(request.userId, request.eventId, request.seatNumbers);
            if (booking == null)
            {
                throw new Exception("Booking failed. Unable to create a new booking.");
            }
           
            await _eventRepository.UpdateEventAsync(eventDetails);
            return booking.BookingId;
        }
    }
}
