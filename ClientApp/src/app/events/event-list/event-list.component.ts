import { ModalComponent } from 'angular-custom-modal';
import { ViewChild } from '@angular/core';
//import { EventAddComponent } from './../event-add/event-add.component';
import { Event } from './../../shared/models/event.model';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import * as data from './../../shared/data';


@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  @ViewChild('componentInsideModal') componentInsideModal: ModalComponent;
  search: string;
  events: Event[] = data.events;
  constructor() { }

  ngOnInit() {
  }


 
}
