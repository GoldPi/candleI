import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as data from './../../../shared/data'
import { Person } from 'src/app/shared/models/person.model.';
@Component({
  selector: 'app-guest-details',
  templateUrl: './guest-details.component.html',
  styleUrls: ['./guest-details.component.css']
})
export class GuestDetailsComponent implements OnInit {
  @Input() person: Person;

urlp = '';
  constructor(private route: ActivatedRoute,
    private router: Router) {

      const url = this.router.url.split('/');
      url.pop();
      url.pop();
      this.urlp = url.join('/');
      const id = this.route.snapshot.paramMap.get('id');
      // this.person =data.person.filter(i=>i.Id==id)[0]
    }

  ngOnInit() {
  }

}
