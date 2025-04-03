using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.EventFeature.Query.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Event>>
    {
        readonly IEventRepository _eventRepository;
        public GetAllEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository; 
        }
        public async Task<IEnumerable<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
          var allEvents=  await _eventRepository.GetAllEvents();
          return allEvents;
        }
    }
}
