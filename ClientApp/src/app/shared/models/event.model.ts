import { Person } from './person.model.';
import { Time } from '@angular/common';
import { EventType } from './event-type.enum';

export interface Event {
  Id?: string;
  Title?: string;
  OnDate?: Date | string;
  Host?: Array<Person> | null;
  Star?: string;
  DateTimeStart?: Date | string;
  DateTimeEnd?: Date | string;
  EventType?: EventType;
  GuestOffline?: Array<Person> | null;
  GuestOnline?: Array<Person> | null;
  Venue?: string;
  City?: string;
  State?: string;
  Landmark?: string;
  ImageUrl?: string;
  Description?: string;
}



