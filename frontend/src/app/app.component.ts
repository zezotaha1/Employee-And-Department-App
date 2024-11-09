import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Employee-And-Department-App';
  showEmployee():void{
    let x =document.getElementById("emp");
    if(x)
    {
      x.style.display="block";
    }
    let y=document.getElementById("depart");
    if(y)
    {
      y.style.display="none";
    }
    let z=document.getElementById("empLink");
    if(z)
    {
      z.style.backgroundColor="#8b8888";
    }
    let a=document.getElementById("departLink");
    if(a)
    {
      a.style.backgroundColor="#c0bcbc";
    }

  }
  showDepartment():void{
    let x =document.getElementById("emp");
    if(x)
    {
      x.style.display="none";
    }
    let y=document.getElementById("depart");
    if(y)
    {
      y.style.display="block";
    }
    let z=document.getElementById("empLink");
    if(z)
    {
      z.style.backgroundColor="#c0bcbc";
    }
    let a=document.getElementById("departLink");
    if(a)
    {
      a.style.backgroundColor="#8b8888";
    }
  }
}
