import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landingpage',
  standalone: true,
  imports: [],
  templateUrl: './landingpage.component.html',
  styleUrl: './landingpage.component.css'
})
export class LandingpageComponent {
  constructor(private router: Router) {}

  bookTicket() {
    //alert('Redirecting to ticket booking...');
    this.router.navigate(['/book-ticket']);
  }
}
