import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserAuthService } from '../_services/user-auth.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  regForm = new FormGroup({
    email : new FormControl('',[Validators.required, Validators.email]),
    name: new FormControl('',[Validators.required,Validators.pattern('(^[A-Za-z -]+$)')]),
    address: new FormControl(''),
    gender: new FormControl(''),
    dob: new FormControl('',Validators.required),
    phone: new FormControl('',[Validators.required,Validators.pattern('([0-9 ]{12})')]),
    password: new FormControl('',[Validators.required,Validators.minLength(8),Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')])
   });
  constructor(
    private userService: UserService,
    private router: Router) { }

  ngOnInit(): void {
  }

  get name(){
    return this.regForm.get('name');
  }
  get phone(){
    return this.regForm.get('phone');
  }
  get dob(){
    return this.regForm.get('dob');
  }
  get email() {
    return this.regForm.get('email');
  }
  get password() {
    return this.regForm.get('password');
  }

  resigration(){

    this.userService.resigtration(this.regForm.value).subscribe(
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
