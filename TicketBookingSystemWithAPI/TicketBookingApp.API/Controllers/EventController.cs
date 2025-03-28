using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBookingApp.Application.Features.EventFeature.Command.AddEvent;
using TicketBookingApp.Application.Features.EventFeature.Command.DeleteEvent;
using TicketBookingApp.Application.Features.EventFeature.Command.UpdateEvent;
using TicketBookingApp.Application.Features.EventFeature.Query.GetAllEvents;
using TicketBookingApp.Application.Features.EventFeature.Query.GetEventById;
using TicketBookingApp.Domain;

namespace TicketBookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
           var allEvents= await _mediator.Send(new GetAllEventsQuery());
            return Ok(allEvents);
        }
        [HttpPost]
        public async Task<IActionResult> AddEventAsync(Event events)
        {
            var result =await _mediator.Send(new AddEventCommand(events));
            return Ok(result);
        }

        //GetEventByIdAsync
        [HttpGet("{id}")]
        public async Task<IActionResult>GetEventByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetEventByIdQuery(id));
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventAsync(int id)
        {
            var result = await _mediator.Send(new DeleteEventCommand(id));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEventAsync(Event events)
        {
            var result=await _mediator.Send(new UpdateEventCommand(events));
            return Ok(events);
        }
    }
}
