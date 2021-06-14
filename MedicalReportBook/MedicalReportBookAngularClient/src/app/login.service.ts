import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';  
import {HttpHeaders} from '@angular/common/http';  
import { from, Observable } from 'rxjs';  
import { Register } from "../app/register";  

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  Url :string;  
  token: string='';  
  header : any;  
  constructor(private http : HttpClient) {   
  
    this.Url = 'http://localhost:57071';  
  
    const headerSettings: {[name: string]: string | string[]; } = {};  
    this.header = new HttpHeaders(headerSettings);  
  }  
  Login(model : any){  
    debugger;  
     var a =this.Url+'/api/AppUser/Login';  
   return this.http.post<any>(this.Url+'/api/AppUser/Login',model,{ headers: this.header});  
  }  
   CreateUser(register:Register)  
   {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };  
    return this.http.post<Register[]>(this.Url + '/api/AppUser/Registration', register, httpOptions)  
   }  
}
