import { Component, Inject, Renderer2 } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { DOCUMENT } from '@angular/platform-browser';
import {SPINNER } from 'ngx-ui-loader';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Admin';
  show = false;
  url: string = "";
  SPINNER=SPINNER;
  constructor(private router: Router, @Inject(DOCUMENT) private document: Document, private renderer: Renderer2) { }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.router.events.subscribe((event: any) => {
      const e = event instanceof NavigationEnd;
      if (e) {
       // console.log(this.router.url);
        const split = this.router.url.split('/');
      //  console.log(split);
        if (split.length > 1) {
          if (split[1] === 'auth') {


            this.show = false;
            this.renderer.addClass(this.document.body, 'back');
          } else {
            this.show = true;
            this.renderer.removeClass(this.document.body, 'back');

          }
        } else {
          this.show = true;
          this.renderer.removeClass(this.document.body, 'back');

        }
      }

    })
      ;
  }
}
