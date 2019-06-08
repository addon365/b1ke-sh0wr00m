import { Component } from '@angular/core';
import { User } from './models/user';
import { Login } from './models/login';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  user: Login = new Login();
  title = "Bike Show Room";
  isActiveSession: boolean;

  AppComponent() { }
  ngOnInit(): void {
    this.user.userName="Tamil";
    this.isActiveSession = this.user != null;
  }
  loggedIn(currentUser: Login) {
  }
  logout() {
  }
}
