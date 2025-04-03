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
        public BookTicketCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<int> Handle(BookTicketCommand request, CancellationToken cancellationToken)
        {
            var booking = await  _bookingRepository.BookTicket(request.userId,request.eventId,request.seatNumber);
            if (booking == null)
            {
                throw new Exception("Booking failed. Unable to create a new booking.");
            }

            return  booking.BookingId;
        }
    }
}
