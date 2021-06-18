import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DoctorAuthService {
  private isAuthenticated = new BehaviorSubject<boolean>(false);
  OnDoctorLoggedIn = this.isAuthenticated.asObservable();

  constructor() { }

  doDoctorLogin(status:boolean){
    this.isAuthenticated.next(status);
  }
}
