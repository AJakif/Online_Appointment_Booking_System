import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PatientApiService } from '../_services/patient-api.service';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {

  @ViewChild('myModalClose') modalClose!:ElementRef;
  appointmentId!:string;
  doctorName!: string;
  symptom!:string;
  medication!:string;
  diesis!:string;
  prescription!:string;

  appointment:any;
  constructor(
    private patientService : PatientApiService
  ) { }

  paymentForm = new FormGroup({
    appointmentId : new FormControl(),
    amount: new FormControl()
  });

  ngOnInit(): void {

    this.showAppointments();
  }

  public showAppointments()
  {
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
    this.patientService.payment(this.paymentForm.value).subscribe(
      (response:any)=>{
        console.log(response.message);
        this.modalClose.nativeElement.click();
        this.showAppointments();
      },
      (error)=>{
        console.log(error);
      }
    );
  }

  public getAppData(id:string)
  {
    this.patientService.appointmentAmount(id).subscribe(
      (response:any)=>{
        console.log(response);
         this.paymentForm = new FormGroup({
            appointmentId : new FormControl(response.appointment),
            amount: new FormControl(response.fee)
          });
      },
      (error)=>{
        console.log(error);
      }
    );
  }

  public Details(id:string){
    this.patientService.appointmentDetails(id).subscribe(
      (response:any)=>{
        console.log(response);
        this.appointmentId = response.data.appointmentId;
        this.doctorName = response.data.doctorName;
        this.symptom = response.data.symptom;
        this.medication =response.data.medication;
        this.diesis = response.data.diesis;
        this.prescription = response.data.prescription;
         
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
