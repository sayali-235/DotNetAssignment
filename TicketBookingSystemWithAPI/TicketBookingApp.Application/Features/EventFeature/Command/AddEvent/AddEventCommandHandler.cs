using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.EventFeature.Command.AddEvent
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, Event>
    {
        readonly IEventRepository _eventRepository;
        public AddEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public Task<Event> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var events = _eventRepository.AddEventAsync(request.events);
            return events;
        }
    }
}
