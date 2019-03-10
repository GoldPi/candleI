import { ModalModule } from 'angular-custom-modal';
import { MediaThumbnailModule } from './media/media-thumbnail/media-thumbnail.module';
import { MediaModule } from './media/media.module';
import { GuestsModule } from './guests/guests.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EventsRoutingModule } from './events-routing.module';
import { EventListComponent } from './event-list/event-list.component';
import { EventAddComponent } from './event-add/event-add.component';
import { EventSelectedComponent } from './event-selected/event-selected.component';
import { FilterPipeModule } from 'ngx-filter-pipe';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { TinymceModule } from 'angular2-tinymce';

@NgModule({
  declarations: [EventListComponent, EventAddComponent, EventSelectedComponent],
  imports: [
    CommonModule,
    EventsRoutingModule,
    GuestsModule,
    MediaModule,
    FilterPipeModule ,
    FormsModule,
    ReactiveFormsModule,
    TinymceModule.withConfig({}),
    MediaThumbnailModule,
    ModalModule
  ]
})
export class EventsModule { }
