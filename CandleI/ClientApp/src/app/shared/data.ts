import { Event } from './models/event.model';
import { Person, Designation } from './models/person.model.';

export const person: Person[] = [
  { Name: 'ramo 1', MobileNo: '9386699909', Id: '1', Email: 'mdyusufalam@gmail.com', City: 'Ranchi', State: 'JH', Designation: 'Elder Brother', PersonNature: 0, EventAttendMode: 0 },
  { Name: 'ramo 2', MobileNo: '7631006909', Id: '2', Email: 'mamachicha@gmail.com', City: 'Ranchi', State: 'JH', Designation: 'Mamas Brother', PersonNature: 0, EventAttendMode: 1 },
  { Name: 'ramo 3', MobileNo: '7631006910', Id: '3', Email: 'datadost@gmail.com', City: 'Ranchi', State: 'JH', Designation: 'Mama', PersonNature: 0, EventAttendMode: 2 },
  { Name: 'ramo 4', MobileNo: '9386699909', Id: '4', Email: 'pappughost@gmail.com', City: 'Ranchi', State: 'JH', Designation: 'Checha', PersonNature: 0, EventAttendMode: 3 },
  { Name: 'ramo 1', MobileNo: '7631006909', Id: '1', Email: 'mdyusufalam@gmail.com', City: 'Ranchi', State: 'JH', Designation: 'Elder Brother', PersonNature: 0, EventAttendMode: 0 },
  { Name: 'ramo 2', MobileNo: '9386699909', Id: '2', Email: 'mamachicha@gmail.com', City: 'Ranchi', State: 'JH', Designation: 'Mamas Brother', PersonNature: 0, EventAttendMode: 1 },
  { Name: 'ramo 3', MobileNo: '7631006910', Id: '3', Email: 'datadost@gmail.com', City: 'Ranchi', State: 'JH', Designation: 'Mama', PersonNature: 0, EventAttendMode: 2 },
  { Name: 'ramo 4', MobileNo: '7631006909', Id: '4', Email: 'pappughost@gmail.com', City: 'Ranchi', State: 'JH', Designation: 'Checha', PersonNature: 0, EventAttendMode: 3 }
]


export const events: Event[] = [
  {
    Id: '1',
    Title: 'Cake Party',
    Host: person.slice(1, 3),
    OnDate: '1/12/2019',
    City: 'Ranchi',
    State: 'JH',
    Star: "Ramesh",
    EventType: 1,
    DateTimeStart: Date(),
    DateTimeEnd: Date(),
    Description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
    Landmark: '7th Haven',
    ImageUrl: 'https://images.pexels.com/photos/382297/pexels-photo-382297.jpeg',
    Venue: 'Home',
    GuestOffline: person,
    GuestOnline: person
  },
  {
    Id: '2',
    Title: 'Birthday 2',
    Host: person.slice(4, 7),
    OnDate: '1/12/2019',
    City: 'Ranchi',
    State: 'JH',
    Star: 'Ramesh',
    EventType: 5,
    DateTimeStart: Date(),
    DateTimeEnd: Date(),
    Description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
    Landmark: '7th Haven',
    ImageUrl: 'https://cdn.pixabay.com/photo/2017/07/21/23/57/concert-2527495_960_720.jpg',
    Venue: 'Home',
    GuestOffline: person,
    GuestOnline: person
  },
  {
    Id: '3',
    Title: 'Anv',
    Host: person,
    OnDate: '1/12/2019',
    City: 'Ranchi',
    State: 'JH',
    Star: "Ramesh",
    EventType: 2,
    DateTimeStart: Date(),
    DateTimeEnd: Date(),
    Description: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
    Landmark: '7th Haven',
    ImageUrl: 'https://cdn.pixabay.com/photo/2015/03/26/10/22/band-691224_960_720.jpg',
    Venue: 'Home',
    GuestOffline: person,
    GuestOnline: person
  }

];


export const Designations: Designation[] = [
  {
    Id: 1,
    DesignationTitle: 'CMD',
    TitleAbbreviation: 'CMD',
    SortOrder: 4
  },
  {
    Id: 2,
    DesignationTitle: 'Chairman',
    TitleAbbreviation: 'Chairman',
    SortOrder: 3
  },
  {
    Id: 3,
    DesignationTitle: 'CFO',
    TitleAbbreviation: 'CFO',
    SortOrder: 2
  },
  {
    Id: 4,
    DesignationTitle: 'Area Manager',
    TitleAbbreviation: 'AM',
    SortOrder: 3
  },
  {
    Id: 5,
    DesignationTitle: 'Sales Repersentative',
    TitleAbbreviation: 'SREP',
    SortOrder: 1
  }

];

