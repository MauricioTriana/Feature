import { Component } from '@angular/core';
import { Router } from '@angular/router'; 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AcmeFood';
  constructor(private router:Router){}
  
  irLogin(){    
    this.router.navigate(['login']);
  }

  irPrincipal(){
    this.router.navigate(['principal']);
  }
}
