import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserAuthService } from '../_services/user-auth.service';
import { UserService } from '../_services/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private userAuthService: UserAuthService,
    private router:Router,
    private userService:UserService
  ){}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const token = this.userAuthService.getToken();
      if(token !== 'null'){
        const role:string = route.data["roles"];
        if(role)
        {
          const match = this.userService.roleMatch(role);
          if(match){
            console.log("role matched")
            return true;
          }
          else{
            console.log("role not matched")
            this.router.navigate(['/forbidden']);
            return false;
          }
        }
      }
      
      this.router.navigate(['/login']);
      return false;
  }
  
}
