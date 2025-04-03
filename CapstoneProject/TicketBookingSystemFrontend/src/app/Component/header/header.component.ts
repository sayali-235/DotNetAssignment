import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,  // ✅ Add this line
  imports: [CommonModule,RouterModule], 
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedIn = false;

  constructor(private router: Router) {}

  ngOnInit() {
    this.checkLoginStatus();
  }

  checkLoginStatus() {
    this.isLoggedIn = !!localStorage.getItem('token'); // Check if token exists
  }

  logout() {
    localStorage.removeItem('token'); // Remove token
    localStorage.removeItem('email'); // Remove email if stored
    this.isLoggedIn = false;
    this.router.navigate(['/login']); // Redirect to login page
  }
}
