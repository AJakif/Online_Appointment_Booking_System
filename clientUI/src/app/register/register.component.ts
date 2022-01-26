import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserAuthService } from '../_services/user-auth.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private userService: UserService,
    private router: Router) { }

  ngOnInit(): void {
  }

  resigration(regForm : NgForm){

    this.userService.resigtration(regForm.value).subscribe(
      (response:any)=>{
        console.log(response);
          this.router.navigate(['/'])
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
