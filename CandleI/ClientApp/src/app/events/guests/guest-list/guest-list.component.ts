import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/shared/models/person.model.';
import * as data from './../../../shared/data';

@Component({
  selector: 'app-guest-list',
  templateUrl: './guest-list.component.html',
  styleUrls: ['./guest-list.component.css']
})
export class GuestListComponent implements OnInit {
  search: string;
  list: Person[] = data.person;
  constructor() { }

  ngOnInit() {
  }

}
