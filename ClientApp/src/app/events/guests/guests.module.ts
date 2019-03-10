import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'angular-custom-modal';
import { FilterPipeModule } from 'ngx-filter-pipe';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GuestsRoutingModule } from './guests-routing.module';
import { GuestListComponent } from './guest-list/guest-list.component';
import { GuestAddComponent } from './guest-add/guest-add.component';
import { GuestDetailsComponent } from './guest-details/guest-details.component';
import { NgxSortableModule } from 'ngx-sortable';
import { PersonDesignationComponent } from './person-designation/person-designation.component';
@NgModule({
  declarations: [GuestListComponent, GuestAddComponent, GuestDetailsComponent, PersonDesignationComponent],
  imports: [
    CommonModule,
    GuestsRoutingModule,
    FilterPipeModule,
    FormsModule,
    NgxSortableModule,
    ReactiveFormsModule,
    ModalModule
  ]
})
export class GuestsModule { }
