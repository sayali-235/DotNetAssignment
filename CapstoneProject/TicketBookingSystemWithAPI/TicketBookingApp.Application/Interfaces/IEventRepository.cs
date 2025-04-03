using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Application.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> AddEventAsync(Event events);
        Task<Event> GetEventByIdAsync(int id);
        Task<bool> DeleteEventAsync(int id);
        Task<Event> UpdateEventAsync(Event events);
    }
}
