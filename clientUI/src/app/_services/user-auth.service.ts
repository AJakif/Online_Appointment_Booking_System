import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {
  clearTimeout: any;
  constructor(
    private router:Router
  ) { }

  public setName(name:string){
    localStorage.setItem("name",name);
  }

  public getName(){
    return localStorage.getItem("name");
  }

  public setRole(role:string)
  {
    localStorage.setItem("role", role);
  }

  public getRole() {
    return localStorage.getItem("role");
  }

  public setToken(jwt : string){
    localStorage.setItem("jwt", jwt);
  }

  public getToken():string{
    return JSON.stringify(localStorage.getItem('jwt') || null);
  }

  public clear(){
    localStorage.clear();
    if (this.clearTimeout) {
      clearTimeout(this.clearTimeout);
    }
  }

  public IsLoggedIn(){
    return this.getRole() && this.getToken();
    
  }

  public autoLogout() {
    this.clearTimeout = setTimeout(() => {
      this.clear();
      this.router.navigate(['/']);
    }, 1800000);
  }
}
