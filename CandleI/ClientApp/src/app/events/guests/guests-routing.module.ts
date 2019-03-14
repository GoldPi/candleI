import { AuthGuard } from './../../auth.guard';
import { GuestDetailsComponent } from './guest-details/guest-details.component';
import { GuestAddComponent } from './guest-add/guest-add.component';
import { GuestListComponent } from './guest-list/guest-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PersonDesignationComponent } from './person-designation/person-designation.component';

const routes: Routes = [
  {
    path: '',
    component: GuestListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'details/:pId',
    component: GuestDetailsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'add',
    component: GuestAddComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'designation',
    component: PersonDesignationComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GuestsRoutingModule { }
