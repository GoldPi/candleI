import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './common/header/header.component';
import {  HttpClientModule } from '@angular/common/http';
import { NgxUiLoaderModule } from 'ngx-ui-loader';
import { TinymceModule } from 'angular2-tinymce';
import { ModalModule } from 'angular-custom-modal';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { NotifierModule } from 'angular-notifier';
import { SidebarComponent } from './common/sidebar/sidebar.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidebarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TinymceModule.withConfig({}),
    AngularFontAwesomeModule,
    HttpClientModule,
    NgxUiLoaderModule,
    NotifierModule,
    ModalDialogModule.forRoot(),
    ModalModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
