import { HttpClient } from '@angular/common/http';
import { DepartmentService } from '../service/department.service';
import { DepartmentComponent } from './../department/department.component';
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../service/employee.service';
import { response } from 'express';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: any[] = [];
  newEmployee: any = {};
  updatedEmployee :any={};
  departments: any[] = [];
  constructor(private employeeService: EmployeeService,private departmentService :DepartmentService,private http: HttpClient) 
  {
  }

  ngOnInit(): void {
    //this.getEmployees();
    this.getDepartments();
  }

  getEmployees(): void {
    this.employeeService.getEmployees().subscribe((data:any) => {
      this.employees = data.employees;
    });
  }

  getEmployee(id:number): void {
    this.employeeService.getEmployee(id).subscribe(data => {
      this.updatedEmployee = data;
    },
    error => {
      if (error.status === 400) {
        alert('Bad Request: Please check your input data.');
      } else {
        alert('An error occurred: ' + error.message);
      }
      console.error('Error adding department:', error);
    });
  }

  addEmployee(): void {
    this.employeeService.addEmployee(this.newEmployee).subscribe(() => {
      this.getEmployees();
      this.newEmployee = {};
    });
  }

  updateEmployee():void{
    this.employeeService.updateEmployee(JSON.stringify(this.updatedEmployee)).subscribe(() => {
      this.getEmployees();
      this.updatedEmployee = {};
    });
  }

  deleteEmployee(id: number): void {
    this.employeeService.deleteEmployee(id).subscribe(() => {
      this.getEmployees();
    },
    error => {
      if (error.status === 400) {
        alert('Bad Request: Please check your input data.');
      } else {
        alert('An error occurred: ' + error.message);
      }
      console.error('Error adding department:', error);
    });
  }


  getDepartments(): void {
    this.departmentService.getDepartments().subscribe((data:any) => {
      this.departments = data.departments; // Assign the array directly
    });
  }


  showAddEmployee() {
    
    let _addEmployee=document.getElementById("addEmployee");
    let _updateEmployee =document.getElementById("updateEmployee");
    let _deleteEmployee =document.getElementById("deleteEmployee");
    
    if(_addEmployee)
    {
      _addEmployee.style.display="block";
    }
    if(_updateEmployee)
    {
      _updateEmployee.style.display="none";
    }
    if(_deleteEmployee)
    {
      _deleteEmployee.style.display="none";
    }
  }
  showUpdateEmployee() {
    
    let _addEmployee=document.getElementById("addEmployee");
    let _updateEmployee =document.getElementById("updateEmployee");
    let _deleteEmployee =document.getElementById("deleteEmployee");
    
    if(_addEmployee)
    {
      _addEmployee.style.display="none";
    }
    if(_updateEmployee)
    {
      _updateEmployee.style.display="block";
    }
    if(_deleteEmployee)
    {
      _deleteEmployee.style.display="none";
    }
    
  }
  showDeleteEmployee() 
  {
    let _addEmployee=document.getElementById("addEmployee");
    let _updateEmployee =document.getElementById("updateEmployee");
    let _deleteEmployee =document.getElementById("deleteEmployee");
    if(_addEmployee)
    {
      _addEmployee.style.display="none";
    }
    if(_updateEmployee)
    {
      _updateEmployee.style.display="none";
    }
    if(_deleteEmployee)
    {
      _deleteEmployee.style.display="block";
    }
    
  }
}
