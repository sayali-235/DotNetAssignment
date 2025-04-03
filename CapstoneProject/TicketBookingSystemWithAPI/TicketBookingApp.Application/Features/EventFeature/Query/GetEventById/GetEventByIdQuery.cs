using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Features.EventFeature.Query.GetEventById
{
    public record GetEventByIdQuery(int id):IRequest<Event>;
    
}
