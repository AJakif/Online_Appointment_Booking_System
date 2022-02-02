import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PatientApiService } from '../_services/patient-api.service';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent implements OnInit {

  appointmentForm = new FormGroup({
    specialization : new FormControl('',Validators.required),
    doctorId: new FormControl('',Validators.required),
    appointmentDate: new FormControl('',Validators.required),
    appointmentTime: new FormControl('',Validators.required),
    symptom: new FormControl(''),
    medication: new FormControl('')
  });
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

  get specialization(){
    return this.appointmentForm.get('specialization');
  }
  get doctorId(){
    return this.appointmentForm.get('doctorId');
  }
  get appointmentDate(){
    return this.appointmentForm.get('appointmentDate');
  }
  get appointmentTime(){
    return this.appointmentForm.get('appointmentTime');
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

  appointment(){

    this.patientService.appointment(this.appointmentForm.value).subscribe(
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
