import { Component, OnInit } from '@angular/core';
import { Booking, BookingStatus } from '../../Models/booking';
import { BookingService } from '../../Services/booking.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-booking',
  standalone: true,
  imports: [CommonModule, FormsModule], // Ensure FormsModule is included
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'] // Changed from styleUrl to styleUrls
})
export class BookingComponent implements OnInit {
  booking: Booking = new Booking();
  bookings: Booking[] = [];
  bookingStatusEnum = BookingStatus; // Ensure correct enum usage

  constructor(private bookingService: BookingService) {
    console.log('BookingComponent initialized');
  }

  ngOnInit(): void {
    console.log('ngOnInit executed');
    this.getAllBookings();
  }

  getAllBookings() {
    this.bookingService.getAllBookings().subscribe(res => {
      console.log(res);
      this.bookings = res?.map(booking => ({
        ...booking,
        bookingStatus: booking.bookingStatus ?? BookingStatus.Pending // Default to Pending if undefined
      })) || [];
    });
  }

}
