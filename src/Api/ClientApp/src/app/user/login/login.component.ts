import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Login } from '../../models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: Login;
  showSpinner: boolean;
  @Output() afterLogged = new EventEmitter<Login>();
  constructor() {
    this.showSpinner = false;
  }

  ngOnInit() {
    this.user = new Login();

  }

  login() {

  }

}
