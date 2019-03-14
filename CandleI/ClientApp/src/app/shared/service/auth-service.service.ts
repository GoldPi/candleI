import { Token } from "./../models/token.model";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../../environments/environment";
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { NotifierService } from 'angular-notifier';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: "root"
})
export class AuthServiceService {
  constructor(private http: HttpClient, private ngxService: NgxUiLoaderService, private alert: NotifierService) { }

  dologin(userName: string, Password: string): Observable<any> {
    this.ngxService.startLoader('loader-01');
    //console.log(environment.baseUrl);

    var userData =
      "username=" + userName + "&password=" + Password + "&grant_type=password";
    var reqHeader = new HttpHeaders({
      "Content-Type": "application/x-www-form-urlencoded",
      "No-Auth": "True"
    });
    return this.http.post<Token>(environment.baseUrl + "/token", userData, { headers: reqHeader }).pipe(
      map(r => {
        this.alert.notify('success', 'Login Successful');
        this.ngxService.stopLoader('loader-01');
        return r;
      }), catchError((e: any, t: Observable<Token>) => {
        this.ngxService.stopLoader('loader-01');
        this.alert.notify('error', 'Login failed');
        return null;
      })
    );
  }
}
