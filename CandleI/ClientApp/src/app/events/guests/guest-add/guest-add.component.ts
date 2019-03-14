import * as data from './../../../shared/data';
import { Component, OnInit, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from 'src/app/shared/models/person.model.';

@Component({
  selector: 'app-guest-add',
  templateUrl: './guest-add.component.html',
  styleUrls: ['./guest-add.component.css']
})
export class GuestAddComponent implements OnInit {
urlp="";
EventName="Yousuf's Birthday";
list: Person[] =  data.person;
@HostListener('window:resize', ['$event'])
public innerHeight: any;
  constructor(private router:Router) {
    var url = this.router.url.split('/')
    url.pop();
    this.urlp = url.join('/');
   }

  ngOnInit() {
    this.innerHeight = (window.innerHeight - 150);
  }

  onResize(event) {
    this.innerHeight = (window.innerHeight - 150);
  }

}
