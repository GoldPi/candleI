import { PersonNature } from './../../shared/models/person-nature.enum';
import { EventType } from 'src/app/shared/models/event-type.enum';
import { Event } from './../../shared/models/event.model';
import { Component, OnInit, Inject, Renderer2, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as data from './../../shared/data';
import { DOCUMENT } from '@angular/platform-browser';
import { EventAttendMode } from './../../shared/models/event-attend-mode.enum';


@Component({
  selector: 'app-event-selected',
  templateUrl: './event-selected.component.html',
  styleUrls: ['./event-selected.component.css']
})
export class EventSelectedComponent implements OnInit {
  eventType = EventType;
  event: Event;
  personNature = PersonNature;
  eventAttentMode = EventAttendMode;
  constructor(private route: ActivatedRoute, private elRef: ElementRef,
    private router: Router, @Inject(DOCUMENT) private document: Document, private renderer: Renderer2) {

    const id = this.route.snapshot.paramMap.get('id');
    this.event = data.events.filter(i => i.Id === id)[0];
  }


  ngOnInit() {

    // this.renderer.addClass(this.document.body, 'image-preview');
    // this.renderer.setStyle(this.document.body, 'background-image', 'url(' + this.event.imageUrl + ')');
    // const divitem = this.renderer.createElement('<div>');
    // const text = this.renderer.createText('Click here to add li');
    //  this.renderer.appendChild(divitem, text);
    // this.renderer.appendChild(this.document.body, divitem);
  }

}
