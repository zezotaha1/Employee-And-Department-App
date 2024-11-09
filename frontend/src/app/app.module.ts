import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './employee/employee.component';
import { DepartmentComponent } from './department/department.component';
import { FormsModule } from '@angular/forms';
import { EmployeeService } from './service/employee.service';
import { DepartmentService } from './service/department.service';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    DepartmentComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    DepartmentService,
    EmployeeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
