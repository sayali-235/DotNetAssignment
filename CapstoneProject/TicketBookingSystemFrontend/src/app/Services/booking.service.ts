import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Booking } from '../Models/booking';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
  
})
export class BookingService {
  private http=inject(HttpClient)
  private apiUrl='https://localhost:7024/api/Booking'
//https://localhost:7024/api/Booking
  // constructor(private httpClient:HttpClient) { }
  getAllBookings():Observable<Booking[]>{
      return this.http.get<Booking[]>(this.apiUrl)
  }
  bookTicket(userId: number, eventId: number, seatNumbers: number[]): Observable<Booking> {
    const payload = { userId, eventId, seatNumbers };
    return this.http.post<Booking>(this.apiUrl, payload);
  }
  
  cancelBooking(bookingId: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${bookingId}`);
  }
  
}
