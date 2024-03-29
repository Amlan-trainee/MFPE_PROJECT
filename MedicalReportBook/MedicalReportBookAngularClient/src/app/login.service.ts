import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {HttpHeaders} from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { Register } from "../app/register";
// import{RequestOptions} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  Url :string;
  token: string='';
  header ;
  constructor(private http : HttpClient) {

    this.Url = 'http://localhost:57071/api/AppUser/';

    const headerSettings: {[name: string]: string | string[]; } = {};
    this.header = new HttpHeaders(headerSettings);
  }
  Login(model : any){
    // debugger;
     var a =this.Url+'Login';
   return this.http.post<any>(a,model,{ headers: this.header});

  //  let headers = new Headers({ 'Content-Type': 'application/json' });
  //   let options = new RequestOptions({ headers: headers });

  //   return this.http.post(this.Url, JSON.stringify({}), options).catch(this.handleError);
  }
   CreateUser(register:Register)
   {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Register[]>(this.Url +'Registration', register,httpOptions)
   }
}
