import { Component } from '@angular/core';
import { BookingService } from '../../Services/booking.service';
import { Booking, BookingStatus } from '../../Models/booking';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { Router }from '@angular/router';
@Component({
  selector: 'app-book-ticket',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule,FormsModule],
  templateUrl: './book-ticket.component.html',
  styleUrls: ['./book-ticket.component.css']
})
export class BookTicketComponent {
  bookings: Booking[] = [];
 // bookingForm: FormGroup;
 seatNumberInput: string = "";
 newBooking: Booking = {
  userId: undefined,
  eventId: undefined,
  seatNumbers: [],
  bookingDate: new Date(),  // Default to current date
  bookingStatus: BookingStatus.Pending     // Default to "Pending"
};
  constructor(private fb: FormBuilder, private bookingService: BookingService,private router: Router) {
    console.log('BookTicketComponent Constructor');
   
  }

  bookTicket(): void {
    // Convert seatNumberInput to an array of integers
    const seatNumbers = this.seatNumberInput.split(',')
      .map(num => parseInt(num.trim(), 10))
      .filter(num => !isNaN(num));
  
    if (!this.newBooking.userId || !this.newBooking.eventId || seatNumbers.length === 0) {
      Swal.fire({
        title: 'Error!',
        text: 'Please fill in all the details correctly!',
        icon: 'error',
        confirmButtonText: 'OK'
      });
      return;
    }
  
    console.log("Booking Request:", { userId: this.newBooking.userId, eventId: this.newBooking.eventId, seatNumbers });
  
    this.bookingService.bookTicket(this.newBooking.userId, this.newBooking.eventId, seatNumbers).subscribe({
      next: (res) => {
        console.log("Booking successful", res);
        this.bookings.push(res);
  
        Swal.fire({
          title: 'Success!',
          text: `Booking for Event ID ${this.newBooking.eventId} has been added successfully.`,
          icon: 'success',
          confirmButtonText: 'OK'
        }).then(() => {
          this.router.navigate(['/bookings']);
        });
  
        // Reset form
        this.newBooking = { userId: undefined, eventId: undefined, seatNumbers: [] };
        this.seatNumberInput = "";
      },
      error: (err) => {
        console.error('Booking Failed:', err);
        Swal.fire({
          title: 'Booking Failed!',
          text: 'An error occurred while adding the booking. Please try again.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    });
  }
  
  }
