import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthService {

  private isAuthenticated = new BehaviorSubject<boolean>(false);
  OnAdminLoggedIn = this.isAuthenticated.asObservable();

  constructor() { }

  doAdminLogin(status:boolean){
    this.isAuthenticated.next(status);
  }
}
