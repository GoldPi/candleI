import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MediaRoutingModule } from './media-routing.module';
import { MediaListComponent } from './media-list/media-list.component';
import { MediaUploadComponent } from './media-upload/media-upload.component';
import { NgxUploaderModule } from 'ngx-uploader';

@NgModule({
  declarations: [MediaListComponent, MediaUploadComponent],
  imports: [
    NgxUploaderModule,
    CommonModule,
    MediaRoutingModule
  ]
})
export class MediaModule { }
