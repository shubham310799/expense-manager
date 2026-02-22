import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ExpenseGroup } from '../Models/ExpenseGroup';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExpenseGroupService {

  constructor(private httpClient: HttpClient) { }

  GetAllExpenseGroups():Observable<any>{
    return this.httpClient.get("http://localhost:5248/api/expense-group/get-all");
  }
}
