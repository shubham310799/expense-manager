import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { LoginService } from '../../Services/login.service';
import { NgClass } from '@angular/common';
import { EmailValidatorDirective } from "../../Directives/email-validator.directive";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, MatIconModule, NgClass, EmailValidatorDirective, EmailValidatorDirective],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email:string = "";
  password:string="";
  sendingReq:boolean=false;
  showPassword:boolean = false;
  constructor(private loginService : LoginService, private router:Router){

  }
  HandleSubmit(){
    this.sendingReq=true;
    this.loginService.Login({userId:this.email, password:this.password}).subscribe({
      next: (data)=>{
        this.sendingReq=false;
        console.log("login Successful");
        console.log(data);
        this.router.navigate(['/home']);
      },
      error: (err)=>{
        this.sendingReq=false;
        console.log("login failed");
        console.log(err);
      },
      complete:()=>{
        console.log("completed");
      }
    });
  }
  ToggleShowPassword(){
    this.showPassword=!this.showPassword;
  }
}
