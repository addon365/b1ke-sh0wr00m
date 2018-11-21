import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { User } from '../../models/user';
import { Login } from '../../models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: Login;
  @Output() afterLogged = new EventEmitter<Login>();
  constructor() {

  }

  ngOnInit() {
    this.user = new Login();

  }

  login() {
    
  }

}
