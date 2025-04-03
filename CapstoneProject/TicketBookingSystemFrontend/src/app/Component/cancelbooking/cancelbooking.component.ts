import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookingService } from '../../Services/booking.service';
import { Booking, BookingStatus } from '../../Models/booking';

@Component({
  selector: 'app-cancelbooking',
  standalone: true,
  imports: [CommonModule], // ✅ Make sure CommonModule is included
  templateUrl: './cancelbooking.component.html',
  styleUrls: ['./cancelbooking.component.css']
})
export class CancelbookingComponent implements OnInit {
  bookings: Booking[] = []; // ✅ Use strongly typed Booking model

  constructor(private bookingService: BookingService) {}

  ngOnInit(): void {
    this.getBookings(); // ✅ Fetch bookings when the component loads
  }

  getBookings(): void {
    this.bookingService.getAllBookings().subscribe({
      next: (data: Booking[]) => {  // ✅ Use 'Booking[]' instead of 'any[]'
        this.bookings = data;
      },
      error: (err:any) => {
        console.error("Error fetching bookings:", err);
      }
    });
  }

  cancelBooking(bookingId: number): void {
    this.bookingService.cancelBooking(bookingId).subscribe({
    
      next: (response: boolean) => { 
        if (response) {
          alert('Booking cancelled successfully');
          this.bookings = this.bookings.filter(b => b.bookingId !== bookingId);
        } else {
          alert('Failed to cancel booking');
        }
      },
      error: (err:any) => {
        console.error("Error canceling booking:", err);
        alert("An error occurred while canceling the booking.");
      }
    });
    
  }
}
