import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { PatientApiService } from 'src/app/_services/patient-api.service';
import { UserAuthService } from 'src/app/_services/user-auth.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent implements OnInit {

  @ViewChild('specialization') spec!: ElementRef;
  specializations:any;
  doctors:any;
  selected!:number;
  constructor(
    private patientService : PatientApiService,
    private router: Router
    ) { }

  ngOnInit(): void {

    this.patientService.specializations().subscribe(
      (response:any)=>{
        this.specializations=response.data;
      },
      (error)=>{
        console.log(error);
      }
    );
  }

 public HandleChange(val:any){
    this.patientService.doctor(val).subscribe(
      (response:any)=>{
        this.doctors=response.data;
      },
      (error)=>{
        console.log(error);
      }
    );

  }

  appointment(appointmentForm : NgForm){

    this.patientService.appointment(appointmentForm.value).subscribe(
      (response:any)=>{
        console.log(response);
          this.router.navigate(['/patient/dashboard'])
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
