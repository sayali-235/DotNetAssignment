using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketBookingApp.Application.Exceptions;
using TicketBookingApp.Application.Interfaces;
using TicketBookingApp.Domain;
using TicketBookingApp.Domain.Constants;
using TicketBookingApp.Infrastructure.Context;

namespace TicketBookingApp.Infrastructure.Repository
{
    public class BookingRepository : IBookingRepository
    {
        readonly TicketBookingDbContext _ticketBookingDbContext;
        public BookingRepository(TicketBookingDbContext ticketBookingDbContext)
        {
            _ticketBookingDbContext= ticketBookingDbContext;
        }

        public async Task<IEnumerable<int>> ShowAvailableSeats(int eventId)
        {
            var eventDetails =await  _ticketBookingDbContext.Events
                 .FirstOrDefaultAsync(e => e.EventId == eventId);
                 
            if (eventDetails == null)
            {
                throw new NotFoundException($"Event with  event Id::{eventId} not found");

            }

            int totalSeats = eventDetails.TotalSeats;
            var bookings = await _ticketBookingDbContext.Bookings
               .Where(b => b.EventId == eventId)
               .ToListAsync(); // Fetch to memory first

            // Extract booked seat numbers in-memory
            var bookedSeats = bookings
                .SelectMany(b => b.SeatNumbers)
                .ToList();

            // Get available seats
            var availableSeats = Enumerable.Range(1, totalSeats)
                .Except(bookedSeats) // Remove booked seats
                .ToList();
            return availableSeats;
        }

        //public async Task<Booking> BookTicket(int userId, int eventId, List<int> seatNumbers)
        //{
        //    var eventDetails = await _ticketBookingDbContext.Events.FirstOrDefaultAsync(e => e.EventId == eventId);
        //    if (eventDetails == null || eventDetails.AvailableSeats < seatNumbers.Count)
        //    {
        //        throw new  BadRequestException("No available seats for this event");
        //    }
        //    var booking = new Booking
        //    {
        //        UserId = userId,
        //        EventId = eventId,
        //        SeatNumbers = seatNumbers,
        //        BookingDate = DateTime.Now,
        //        BookingStatus=BookingStatus.Pending

        //    };
        //    eventDetails.AvailableSeats-=seatNumbers.Count;
        //    _ticketBookingDbContext.Events.Update(eventDetails);
        //   var result=   await _ticketBookingDbContext.Bookings.AddAsync(booking);
        //    await _ticketBookingDbContext.SaveChangesAsync();
        //    return result.Entity;// Ensure you return the tracked entity
        //}
        public async Task<Booking> BookTicket(int userId, int eventId, List<int> seatNumbers)
        {
            var eventDetails = await _ticketBookingDbContext.Events
                .FirstOrDefaultAsync(e => e.EventId == eventId);

            if (eventDetails == null)
            {
                throw new NotFoundException("Event not found");
            }

            // Fetch all existing bookings for this event into memory
            var existingBookings = await _ticketBookingDbContext.Bookings
                .Where(b => b.EventId == eventId)
                .ToListAsync();

            // Extract booked seats in-memory
            var bookedSeats = existingBookings.SelectMany(b => b.SeatNumbers).ToList();

            // Check if any requested seat is already booked
            var alreadyBookedSeats = seatNumbers.Intersect(bookedSeats).ToList();
            if (alreadyBookedSeats.Any())
            {
                throw new BadRequestException($"Seats {string.Join(", ", alreadyBookedSeats)} are already booked. Please choose different seats.");
            }

            // Ensure enough available seats
            if (eventDetails.AvailableSeats < seatNumbers.Count)
            {
                throw new BadRequestException("Not enough available seats");
            }

            var booking = new Booking
            {
                UserId = userId,
                EventId = eventId,
                SeatNumbers = seatNumbers,
                BookingDate = DateTime.Now,
                BookingStatus = BookingStatus.Pending
            };

            eventDetails.AvailableSeats -= seatNumbers.Count;
            _ticketBookingDbContext.Events.Update(eventDetails);

            var result = await _ticketBookingDbContext.Bookings.AddAsync(booking);
            await _ticketBookingDbContext.SaveChangesAsync();

            return result.Entity;
        }




        public async Task<bool> CancelBooking(int bookingId)
        {
          
            var booking = await GetBookingById(bookingId);
            if(booking is not null)
            {
                var eventDetails = await _ticketBookingDbContext.Events.FirstOrDefaultAsync(b => b.EventId == booking.EventId);
                if(eventDetails !=null)
                {
                    eventDetails.AvailableSeats+=booking.SeatNumbers.Count;
                    _ticketBookingDbContext.Events.Update(eventDetails);
                }
                _ticketBookingDbContext.Remove(booking);
              return   await _ticketBookingDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
             return await _ticketBookingDbContext.Bookings
                .Include(e=>e.Event)
                .Include(u=>u.User)
                .ToListAsync();
        }

        public async Task <Booking> GetBookingById(int bookingId)
        { 
            return await _ticketBookingDbContext.Bookings.FirstOrDefaultAsync(b => b.BookingId == bookingId);
        }


        public async Task<Booking> UpdateBooking(int userId, int bookingId, int? newEventId, List<int>? newSeatNumbers)
        {
            var booking = await _ticketBookingDbContext.Bookings
                .Include(b => b.Event)
                .FirstOrDefaultAsync(b => b.UserId == userId && b.BookingId == bookingId);

            if (booking == null)
                throw new Exception("Booking not found");

            var currentEvent = booking.Event;

            // Restore previous seats before updating
            currentEvent.AvailableSeats += booking.SeatNumbers.Count;  // Add back the previously booked seats
            _ticketBookingDbContext.Events.Update(currentEvent);  // Update the old event with the restored seat count

            // If event is changed
            if (newEventId.HasValue && newEventId.Value != booking.EventId)
            {
                var newEvent = await _ticketBookingDbContext.Events
                    .FirstOrDefaultAsync(e => e.EventId == newEventId.Value);

                if (newEvent == null || newEvent.AvailableSeats < booking.SeatNumbers.Count)
                    throw new BadRequestException("Not enough seats available in the new event");

                // Restore seats in the new event before making changes
                // Update event details
                booking.EventId = newEventId.Value;
                booking.Event = newEvent;

                // Deduct seats from the new event
                newEvent.AvailableSeats -= booking.SeatNumbers.Count;
                _ticketBookingDbContext.Events.Update(newEvent);  // Update new event with the deducted seats
            }

            // If seat numbers are changed
            if (newSeatNumbers != null && newSeatNumbers.Count > 0)
            {
                // Calculate the number of seats being removed and added
                int seatsToRemove = booking.SeatNumbers.Count - newSeatNumbers.Count;

                if (seatsToRemove > 0) // If seats are being reduced
                {
                    if (currentEvent.AvailableSeats < seatsToRemove)
                        throw new BadRequestException("Not enough available seats in the event");

                    currentEvent.AvailableSeats -= seatsToRemove;  // Deduct the removed seats from the current event
                }
                else if (seatsToRemove < 0) // If seats are being added
                {
                    currentEvent.AvailableSeats += (-seatsToRemove);  // Add back the newly added seats
                }

                // Update the seat numbers in the booking
                booking.SeatNumbers = newSeatNumbers;

                // Ensure the correct seat count is reflected in the current event
                _ticketBookingDbContext.Events.Update(currentEvent);  // Update the event with the new seat count
            }

            _ticketBookingDbContext.Bookings.Update(booking);  // Update the booking itself
            await _ticketBookingDbContext.SaveChangesAsync();  // Save all changes

            return booking;  // Return the updated booking
        }


    }
}
