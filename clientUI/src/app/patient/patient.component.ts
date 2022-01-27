import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { PatientApiService } from '../_services/patient-api.service';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {

  appId!:string;
  amount!: number;
  appointment:any = null;
  constructor(
    private patientService : PatientApiService,
    private router : Router
  ) { }

  paymentForm = new FormGroup({
    appointmentId : new FormControl(this.appId),
    amount: new FormControl(this.amount)
  });

  ngOnInit(): void {

    this.patientService.appointments().subscribe(
      (response:any)=>{
        console.log(response.appointmentList)
        this.appointment=response.appointmentList;
      },
      (error)=>{
        console.log(error);
      }
    );
  }

  public pay( ) {
    console.log(this.paymentForm.value);
    // this.modal.hide();
    
    this.patientService.payment(this.paymentForm.value).subscribe(
      (response:any)=>{
        console.log(response.message);
        this.router.navigate(['/patient/dashboard'])
      },
      (error)=>{
        console.log(error);
      }
    );
  }

  public getAppData(id:string)
  {
    console.log(id);
    this.patientService.appointmentAmount(id).subscribe(
      (response:any)=>{
        console.log(response);
        this.appId = response.appointment;
          this.amount = response.fee;
         this.paymentForm = new FormGroup({
            appointmentId : new FormControl(this.appId),
            amount: new FormControl(this.amount)
          });
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
