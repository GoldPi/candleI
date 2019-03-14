import { Router } from '@angular/router';
import { AuthServiceService } from './../../shared/service/auth-service.service';
import { Component, OnInit } from '@angular/core';
import { Token } from 'src/app/shared/models/token.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username: string;
  password: string;
  constructor(private service: AuthServiceService, private route: Router) { }

  ngOnInit() {
  }

  login() {
    this.service.dologin(this.username, this.password).subscribe((i: Token) => {
      Token.Save(i);
      this.route.navigate(['events']);
    }, error => {
      alert("Login failed" + JSON.stringify(error));
    });
  }
}
