import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './Component/login/login.component';
import { RegisterComponent } from './Component/register/register.component';
import { HeaderComponent } from './Component/header/header.component';
import { BookingComponent } from './Component/booking/booking.component';
import { BookTicketComponent } from './Component/book-ticket/book-ticket.component';
import { CancelbookingComponent } from './Component/cancelbooking/cancelbooking.component';
import { LandingpageComponent } from './Component/landingpage/landingpage.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,LoginComponent,RegisterComponent,HeaderComponent, BookingComponent, BookTicketComponent ,CancelbookingComponent,LandingpageComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TicketBookingSystemApp';
}
