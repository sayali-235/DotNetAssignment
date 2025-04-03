using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.EventFeature.Command.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Event>
    {
        readonly IEventRepository _eventRepository;
        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public Task<Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var events = _eventRepository.UpdateEventAsync(request.events);
            return events;
        }
    }
}
