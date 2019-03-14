import * as data from '../data';
import { Designation } from '../models/person.model.';
import { Injectable } from '@angular/core';
import { NotifierService } from 'angular-notifier';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { HttpClient } from '@angular/common/http';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonDesigantionService {
  dummy: Designation[];
  constructor(private http: HttpClient, private ngxService: NgxUiLoaderService, private alert: NotifierService) {
    this.dummy = data.Designations;
  }


  get data(): Observable<Designation[]> {
    //console.log(this.dummy);
    return of(this.dummy.sort(this.sortFun));
  }

  sortFun(a: Designation, b: Designation) {
    if (a.SortOrder < b.SortOrder) {
      return -1;
    }
    if (a.SortOrder > b.SortOrder) {
      return 1;
    }
    return 0;
  }
  remove(item): Observable<any> {
    return new Observable(observer => {
      this.ngxService.startLoader('loader-01');
      setTimeout(() => {
        const ItemIndex = this.dummy.indexOf(item);
        if (ItemIndex > -1) {
          this.dummy.splice(ItemIndex, 1);
        }
        this.ngxService.stopLoader('loader-01');
        this.alert.notify('success', "Item removed");
        observer.next(1);
        observer.complete();
      }, 3000);
    });

  }

  add(des: Designation): Observable<any> {

    return new Observable(observer => {
      this.ngxService.startLoader('loader-01');
      setTimeout(() => {
        this.ngxService.stopLoader('loader-01');
        const i = this.dummy.findIndex((o: Designation) => o.Id === des.Id);
        if (i !== -1) {
          this.dummy[i] = des;
          console.log(this.dummy);
          this.alert.notify('success', 'Item Saved');
        } else if (this.dummy.filter((o: Designation) => o.DesignationTitle === des.DesignationTitle).length === 0) {
          this.dummy.push(des);
          this.alert.notify('success', 'Item Added');
        } else {
          this.alert.notify('error', 'Item already exist.');

        }
        observer.next(1);
        observer.complete();
      }, 3000);
    });
  }

  reload(): Designation[] {
    return this.dummy;
  }

  saveShorting(des: Designation[]): Observable<any> {

    return new Observable(observer => {
      this.ngxService.startLoader('loader-01');
      setTimeout(() => {
        this.dummy = des;
        this.ngxService.stopLoader('loader-01');
        this.alert.notify('success', 'Item sorted successfully.');
        observer.next(1);
        observer.complete();
      }, 3000);
    });
  }

}
