import { Component, OnInit } from '@angular/core';
import { Expense } from '../../Models/Expense';
import { AddExpenseRequest } from '../../Models/AddExpenseRequest';
import { ExpenseGroupService } from '../../Services/expense-group.service';
import { ExpenseGroup } from '../../Models/ExpenseGroup';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  expenseGroups:ExpenseGroup[] = [];
  addExpenseRequest:AddExpenseRequest = {
    name:"",
    description:"",
    amount:0
  }

  constructor(private expenseGroupService:ExpenseGroupService) {
    
  }

  ngOnInit(){
    this.expenseGroupService.GetAllExpenseGroups().subscribe({
      next: data =>{
        this.expenseGroups = data.data;
        console.log(data);
      },
      error : error=>{
        console.error(error);
      }
    })
  }

  addExpense(){

  }

  openExpenseForm(){

  }
}
