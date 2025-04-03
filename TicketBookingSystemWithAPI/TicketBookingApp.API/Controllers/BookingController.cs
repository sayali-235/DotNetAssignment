using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBookingApp.Application.Features.BookingFeature.Command.BookTicket;
using TicketBookingApp.Application.Features.BookingFeature.Command.CancelBooking;
using TicketBookingApp.Application.Features.BookingFeature.Query.GetAllBookings;
using TicketBookingApp.Application.Features.BookingFeature.Query.GetBookingByUserId;
using TicketBookingApp.Application.Features.EventFeature.Command.DeleteEvent;
using TicketBookingApp.Application.Features.EventFeature.Query.GetEventById;
using TicketBookingApp.Domain;

namespace TicketBookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllBookings()
        {
            var allBookings=await _mediator.Send(new GetAllBookingsQuery());    
            return Ok(allBookings);
        }
        [HttpPost]
        public async Task<IActionResult>BookTicket(int userId,int eventId,int seatNumber)
        {
            var command = new BookTicketCommand(userId, eventId, seatNumber);
            var booking = await _mediator.Send(command);
            return Ok(booking);

        }
        [HttpGet("{bookingId}")]
        public async Task<IActionResult>GetBookingById(int bookingId)
        {
             
            var result = await _mediator.Send(new GetBookingByIdQuery(bookingId));
            return Ok(result);
        }

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult>CancelBooking(int bookingId)
        {
             
            var result=await _mediator.Send(new CancelBookingCommand(bookingId));
            return Ok(result);
        }
    }
}
