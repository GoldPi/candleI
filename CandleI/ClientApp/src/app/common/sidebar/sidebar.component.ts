import { Token } from 'src/app/shared/models/token.model';
import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  show = false;
  url: string = '';
  constructor(private router: Router) { }
  logout(){
    Token.LogOut();
    this.router.navigate(['auth']);
  }
  ngOnInit() {
    this.router.events.subscribe((event: any) => {
      const e = event instanceof NavigationEnd;
      if (e) {
        console.log(this.router.url);
        const split = this.router.url.split('/');
        console.log(split);
        if (split.length > 2) {
          if (split[2] === 'selected') {
            this.url = split[1] + '/' + split[2] + '/' + split[3];
            this.show = true;
          }

        } else {
          this.show = false;
        }
      }

    })
      ;
  }

}
