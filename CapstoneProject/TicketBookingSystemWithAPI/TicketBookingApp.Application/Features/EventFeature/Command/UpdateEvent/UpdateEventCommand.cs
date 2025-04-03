using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.EventFeature.Command.UpdateEvent
{
    public record UpdateEventCommand(Event events):IRequest<Event>;
     
}
