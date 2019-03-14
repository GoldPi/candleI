import { AuthGuard } from './../auth.guard';
import { EventAddComponent } from './event-add/event-add.component';
import { EventListComponent } from './event-list/event-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { EventSelectedComponent } from './event-selected/event-selected.component';

const routes: Routes = [
  {
    path: '',
    component:EventListComponent, 
    canActivate:[AuthGuard]
  },
  {
    path:'add',
    component:EventAddComponent,
    canActivate:[AuthGuard]
  },
  {
    path: 'selected/:id',
    component: EventSelectedComponent,
    canActivate:[AuthGuard]
  },
  {
    path: 'selected/:id/guest',
    loadChildren:'./guests/guests.module#GuestsModule',
    canActivate:[AuthGuard]
  },
  {
    path: 'selected/:id/media',
    loadChildren:'./media/media.module#MediaModule',
    canActivate:[AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EventsRoutingModule { }
