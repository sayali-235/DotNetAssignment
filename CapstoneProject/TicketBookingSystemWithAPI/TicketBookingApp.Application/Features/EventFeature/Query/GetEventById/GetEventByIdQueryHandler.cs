using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.EventFeature.Query.GetEventById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event>
    {
        readonly IEventRepository _eventRepository;
        public GetEventByIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var eventFindStatus = await _eventRepository.GetEventByIdAsync(request.id);
            return eventFindStatus;
        }
    }
}
