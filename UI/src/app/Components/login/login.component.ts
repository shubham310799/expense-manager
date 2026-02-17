import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { LoginService } from '../../Services/login.service';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, MatIconModule, NgClass],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email:string = "";
  password:string="";
  showPassword:boolean = false;
  constructor(private loginService : LoginService){

  }
  HandleSubmit(){
    console.log(this.email);
    console.log(this.password);
    this.loginService.Login({email:this.email, password:this.password}).subscribe({
      next: (data)=>{
        console.log(data);
      },
      error: (err)=>{
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
