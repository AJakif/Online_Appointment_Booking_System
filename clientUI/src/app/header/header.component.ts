import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserAuthService } from '../_services/user-auth.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(
    private userAuthService: UserAuthService,
    private router: Router,
    private userService:UserService
    ) { }
  ngOnInit(): void { 
  }

  public roleMatch(role:string){
     return this.userService.roleMatch(role);
  }
   
  public isLoggedIn(){
     return this.userAuthService.IsLoggedIn();
  }

  public logout (){
    this.userAuthService.clear();
    this.router.navigate(['/']);
  }
}
