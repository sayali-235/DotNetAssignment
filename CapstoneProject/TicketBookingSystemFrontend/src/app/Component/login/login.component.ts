// import { Component } from '@angular/core';
// import { AuthResponseModel, Login } from '../../Models/login';
// import { UserService } from '../../Services/user.service';
// import { FormsModule, NgForm } from '@angular/forms';
// import { CommonModule } from '@angular/common';
// import { Router } from '@angular/router';

// @Component({
//   selector: 'app-login',
//   standalone: true,
//   imports: [CommonModule, FormsModule],
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.css']
// })
// export class LoginComponent {
//   loginModel: Login = new Login('', '');
//   errorMsg = '';

//   constructor(private userService: UserService, private router: Router) {}  // ✅ Inject Router

//   loginUser(loginForm: NgForm) {
//     this.loginModel = loginForm.value;
//     console.log(this.loginModel);

//     this.userService.login(this.loginModel).subscribe({
//       next: (response: AuthResponseModel) => {
//         console.log('Login success', response);
//         localStorage.setItem('token', response.token);
//         localStorage.setItem('email', response.email);
//         alert('Login Successfully');
//         loginForm.reset();
        
//         this.router.navigateByUrl('landingpage');  // ✅ Redirect to landing page
//       },
//       error: (error) => {
//         console.error('Login Failed', error);
//         this.errorMsg = JSON.stringify(error.error);
//         alert(this.errorMsg);
//       }
//     });
//   }
// }
import { Component, OnInit } from '@angular/core';
import { AuthResponseModel, Login } from '../../Models/login';
import { UserService } from '../../Services/user.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginModel: Login = new Login('', '');
  errorMsg = '';
  isLoggedIn = false;

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit() {
    // ✅ Check if the token exists in localStorage and update isLoggedIn
    const token = localStorage.getItem('token');
    this.isLoggedIn = !!token; // Convert to boolean (true if token exists, false otherwise)
  }

  loginUser(loginForm: NgForm) {
    if (loginForm.invalid) return;

    this.userService.login(this.loginModel).subscribe({
      next: (response: AuthResponseModel) => {
        console.log('Login success', response);
        localStorage.setItem('token', response.token);
        localStorage.setItem('email', response.email);
        this.isLoggedIn = true; // ✅ Update login state after successful login
        alert('Login Successfully');
        loginForm.reset();
        this.router.navigateByUrl('landingpage');
      },
      error: (error) => {
        console.error('Login Failed', error);
        this.errorMsg = 'Invalid credentials. Please try again.';
        alert(this.errorMsg);
      }
    });
  }

  logoutUser() {
    localStorage.removeItem('token');
    localStorage.removeItem('email');
    this.isLoggedIn = false; // ✅ Update state on logout
    this.router.navigateByUrl('/login'); // ✅ Redirect to login page
  }
}

