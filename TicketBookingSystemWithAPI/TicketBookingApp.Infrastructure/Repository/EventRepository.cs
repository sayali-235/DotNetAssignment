using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;
using TicketBookingApp.Infrastructure.Context;

namespace TicketBookingApp.Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        protected TicketBookingDbContext _ticketBookingDbcontext;
        public EventRepository(TicketBookingDbContext ticketBookingDbContext)
        {
            _ticketBookingDbcontext = ticketBookingDbContext;
        }

        public async Task<Event> AddEventAsync(Event events)
        {
            await _ticketBookingDbcontext.Events.AddAsync(events);
            await _ticketBookingDbcontext.SaveChangesAsync();
            return events;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
           var events=await GetEventByIdAsync(id);
            if(events is not null)
            {
                _ticketBookingDbcontext.Remove(events);
                return await _ticketBookingDbcontext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _ticketBookingDbcontext.Events.ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _ticketBookingDbcontext.Events.FirstOrDefaultAsync(b => b.EventId == id);
        }

        public async Task<Event> UpdateEventAsync(Event events)
        {
            Event updateEvent = await GetEventByIdAsync(events.EventId);
            if (updateEvent is not null)
            {
                updateEvent.Name = events.Name;
                updateEvent.Description = events.Description;
                updateEvent.Date = events.Date;
                updateEvent.Venue = events.Venue;
                updateEvent.AvailableSeats = events.AvailableSeats;
                updateEvent.Price = events.Price;
                updateEvent.EventType = events.EventType;
                _ticketBookingDbcontext.Events.Update(updateEvent);
                _ticketBookingDbcontext.SaveChangesAsync();
            }
            return events;
        }
    }
}
