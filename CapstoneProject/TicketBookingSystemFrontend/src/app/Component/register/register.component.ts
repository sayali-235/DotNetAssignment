import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../Services/user.service';
import { response } from 'express';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit 
{
  registerForm!:FormGroup;
  errorMsg='';
  constructor(private userService:UserService,private fb:FormBuilder){}
ngOnInit(): void {
  this.registerForm=this.fb.group({
    firstName:['',Validators.required],
    lastName:['',Validators.required],
    phoneNo:['',Validators.required],
    email:['',[Validators.required,Validators.email]],
    userName:['',Validators.required],
    password:['',Validators.required]
  });
}
registerUser(user:FormGroup){
  this.userService.register(user.value).subscribe({
    next:(response)=>{
      console.log(response);
      alert('Registration Success');
      this.registerForm?.reset();
    
    },
    error:(err)=>{
      console.error('register Failed',err);
      this.errorMsg=JSON.stringify(err.error)
      alert(this.errorMsg)
    },
     
  })
}
}
