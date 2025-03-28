using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.EventFeature.Command.AddEvent
{
    public record AddEventCommand(Event events):IRequest<Event>;
     
}
