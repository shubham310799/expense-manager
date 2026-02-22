import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {


  private http: HttpClient;
  constructor(private httpBackend:HttpBackend, private jwtHelperService:JwtHelperService){
    this.http=new HttpClient(httpBackend);
  }

  Login(reqBody:any):Observable<any>{
    return this.http.post("http://localhost:5248/api/user/login", reqBody);
  }

  SaveUserSession(data:string){
    sessionStorage.setItem("userBearerToken", data);
  }

  Logout(){
    sessionStorage.removeItem("userBearerToken");
  }

  IsActiveSession():boolean{
    console.log(this.jwtHelperService.isTokenExpired());
    if(this.jwtHelperService.isTokenExpired()){
      return false;
    }
    return true;
  }
}
