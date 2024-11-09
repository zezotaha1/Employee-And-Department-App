import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../service/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  departments: any[] = [];
  newDepartment: any = {};
  updatedDepartment:any={};  
  constructor(private departmentService: DepartmentService) {}

  ngOnInit(): void {
    this.getDepartments();
  }

  getDepartments(): void {
    this.departmentService.getDepartments().subscribe((data:any) => {
      this.departments = data.departments; // Assign the array directly
    });
  }

  getDepartment(id:number): any {
    this.departmentService.getDepartment(id).subscribe(data => {
      this.updatedDepartment = data; // Assign the array directly
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
  
  addDepartment(): void {
    this.departmentService.addDepartment(this.newDepartment).subscribe(() => {
      this.getDepartments();
      this.newDepartment = {};
    });
  }
  updateDepartment():void{
    this.departmentService.updateDepartment(JSON.stringify(this.updatedDepartment)).subscribe(() => {
      this.getDepartments();
      this.updatedDepartment = {};
    });
  }

  deleteDepartment(id: number): void {
    this.departmentService.deleteDepartment(id).subscribe(() => {
      this.getDepartments();
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

  showAllDepartment():void
  {
    let _allDepartment =document.getElementById("allDepartment");
    let _addDepartment=document.getElementById("addDepartment");
    let _updateDepartment =document.getElementById("updateDepartment");
    let _deleteDepartment =document.getElementById("deleteDepartment");
    if(_allDepartment)
    {
      _allDepartment.style.display="block";
    }
    if(_addDepartment)
    {
      _addDepartment.style.display="none";
    }
    if(_updateDepartment)
    {
      _updateDepartment.style.display="none";
    }
    if(_deleteDepartment)
    {
      _deleteDepartment.style.display="none";
    }
  }
  showAddDepartment() {
    let _allDepartment =document.getElementById("allDepartment");
    let _addDepartment=document.getElementById("addDepartment");
    let _updateDepartment =document.getElementById("updateDepartment");
    let _deleteDepartment =document.getElementById("deleteDepartment");
    if(_allDepartment)
    {
      _allDepartment.style.display="none";
    }
    if(_addDepartment)
    {
      _addDepartment.style.display="block";
    }
    if(_updateDepartment)
    {
      _updateDepartment.style.display="none";
    }
    if(_deleteDepartment)
    {
      _deleteDepartment.style.display="none";
    }
  }
  showUpdateDepartment() {
    let _allDepartment =document.getElementById("allDepartment");
    let _addDepartment=document.getElementById("addDepartment");
    let _updateDepartment =document.getElementById("updateDepartment");
    let _deleteDepartment =document.getElementById("deleteDepartment");
    if(_allDepartment)
    {
      _allDepartment.style.display="none";
    }
    if(_addDepartment)
    {
      _addDepartment.style.display="none";
    }
    if(_updateDepartment)
    {
      _updateDepartment.style.display="block";
    }
    if(_deleteDepartment)
    {
      _deleteDepartment.style.display="none";
    }
    
  }
  showDeleteDepartment() 
  {
    let _allDepartment =document.getElementById("allDepartment");
    let _addDepartment=document.getElementById("addDepartment");
    let _updateDepartment =document.getElementById("updateDepartment");
    let _deleteDepartment =document.getElementById("deleteDepartment");
    if(_allDepartment)
    {
      _allDepartment.style.display="none";
    }
    if(_addDepartment)
    {
      _addDepartment.style.display="none";
    }
    if(_updateDepartment)
    {
      _updateDepartment.style.display="none";
    }
    if(_deleteDepartment)
    {
      _deleteDepartment.style.display="block";
    }
    
  }
}
