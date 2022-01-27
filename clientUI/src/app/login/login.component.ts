import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserAuthService } from '../_services/user-auth.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    email : new FormControl('',[Validators.required, Validators.email]),
     password: new FormControl('',[Validators.required,Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[A-Za-z\d$@$!%*?&].{8,}')])
   });

  constructor(
    private userService: UserService,
    private userAuthService:UserAuthService,
    private router: Router

     ) { }

  ngOnInit(): void {
  }

  get email() {
    return this.loginForm.get('email');
  }
  get password() {
    console.log(this.loginForm.get('password'))
    return this.loginForm.get('password');
  }

  login(){

    this.userService.login(this.loginForm.value).subscribe(
      (response:any)=>{
        this.userAuthService.setRole(response.userDetails.type);
        this.userAuthService.setToken(response.token);
        this.userAuthService.setName(response.userDetails.name);
        console.log("Logged in");
        this.userAuthService.autoLogout();

        const role = response.userDetails.type;

        if(role === 'Admin'){
          this.router.navigate(['/admin/dashboard'])
        } else if (role === 'Patient') {
          this.router.navigate(['/patient/dashboard'])
        }else if (role === 'Doctor') {
          this.router.navigate(['/doctor/dashboard'])
        }else if (role === 'Secretary') {
          this.router.navigate(['/secretary/dashboard'])
        }
         else {
          this.router.navigate(['/forbidden'])
        }
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
