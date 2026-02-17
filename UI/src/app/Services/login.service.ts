import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient){
    
  }

  Login(reqBody:any):Observable<any>{
    return this.http.post("http://localhost:5321/login", reqBody);
  }
}
