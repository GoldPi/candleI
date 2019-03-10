import { AuthGuard } from './../../auth.guard';
import { MediaUploadComponent } from './media-upload/media-upload.component';
import { MediaListComponent } from './media-list/media-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    component:MediaListComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'upload',
    component:MediaUploadComponent,
    canActivate:[AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MediaRoutingModule { }
