import { Routes } from '@angular/router';
import { register } from 'module';
import { RegisterComponent } from './Component/register/register.component';
import { LoginComponent } from './Component/login/login.component';
import { BookingComponent } from './Component/booking/booking.component';
import { BookTicketComponent } from './Component/book-ticket/book-ticket.component';
import { CancelbookingComponent } from './Component/cancelbooking/cancelbooking.component';
import { LandingpageComponent } from './Component/landingpage/landingpage.component';

export const routes: Routes = [
    {path:'register', component:RegisterComponent},
    {path:'login', component:LoginComponent},
    {path:'booking',component:BookingComponent},
    {path:'book-ticket',component:BookTicketComponent},
    {path:'cancelbooking',component:CancelbookingComponent},
    {path:'landingpage',component:LandingpageComponent},
    { path: '**', redirectTo: 'landingpage' }

];
