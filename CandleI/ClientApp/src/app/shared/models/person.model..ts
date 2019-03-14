import { PersonNature } from './person-nature.enum';
import { EventAttendMode } from './event-attend-mode.enum';

export interface Person {
  Id: string;
  Name: string;
  MobileNo: null | string;
  Email?: string;
  City?: string;
  State?: string;
  Designation?: string;
  PersonNature?: PersonNature;
  EventAttendMode?: EventAttendMode;
}

export interface Designation {
  Id: number;
  DesignationTitle: string;
  TitleAbbreviation: string;
  SortOrder: number;
  }




