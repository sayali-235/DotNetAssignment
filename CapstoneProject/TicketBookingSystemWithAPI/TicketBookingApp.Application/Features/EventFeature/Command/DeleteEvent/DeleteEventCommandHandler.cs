using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Application.Exceptions;
using TicketBookingApp.Application.Interfaces;

namespace TicketBookingApp.Application.Features.EventFeature.Command.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
    {
        readonly IEventRepository _eventRepository;
        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;   
        }
        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventFindStatus=await _eventRepository.GetEventByIdAsync(request.id);
            //if (eventFindStatus is null)
            //{
            //    throw new NotFoundException($"Event with ID::{request.id} not found");
            //}
            return await _eventRepository.DeleteEventAsync(eventFindStatus.EventId); 
        }
    }
}
