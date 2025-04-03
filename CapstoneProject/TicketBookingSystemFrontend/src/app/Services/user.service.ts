import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthResponseModel, Login } from '../Models/login';
import { Observable } from 'rxjs';
import { Register, RegistrationResponse } from '../Models/register';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl="https://localhost:7024/api/Auth";
//https://localhost:7024/api/Auth/Login
//https://localhost:7024/api/Auth/Register
  constructor(private http:HttpClient) { }
  login(loginData:Login):Observable<AuthResponseModel>{
    return this.http.post<AuthResponseModel>(`${this.apiUrl}/Login`,loginData)
  }
 register(user:Register):Observable<RegistrationResponse>{
  return this.http.post<RegistrationResponse>(`${this.apiUrl}/Register`,user)
 }

}
