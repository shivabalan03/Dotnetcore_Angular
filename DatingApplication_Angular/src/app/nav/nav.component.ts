import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/Alertify.service';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(public authService: AuthService, private alertify: AlertifyService, private route: Router) { }

  ngOnInit() {

  }
  login(){
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Loggin in Successfully..!');
    }, error => {
      this.alertify.error(error.error);
    }, () => {
      this.route.navigate(['/members']);
    });
  }

  loggedIn(){
    // const token = localStorage.getItem('token');
    // return !!token;
    // Instead of above statement we will use
    return this.authService.loggedIn();
  }

  logout(){
    this.alertify.success('Logged out');
    localStorage.removeItem('token');
    this.route.navigate(['/home']);
  }
}
