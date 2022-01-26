import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css']
})
export class AddPatientComponent implements OnInit {

  constructor(
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  resigration(regForm : NgForm){

    this.userService.resigtration(regForm.value).subscribe(
      (response:any)=>{
        console.log(response);
          this.router.navigate(['/admin/dashboard'])
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
