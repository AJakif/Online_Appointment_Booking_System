import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DoctorApiService } from '../_services/doctor-api.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {
  @ViewChild('myModalClose') modalClose!:ElementRef;
  appointmentId!:string;
  patientName!: string;
  doctorName!: string;
  symptom!:string;
  medication!:string;
  diesis!:string;
  prescription!:string;
  appointment:any;
  constructor(private doctorService : DoctorApiService) { }

  prescriptionForm = new FormGroup({
    appointmentId : new FormControl(),
    diesis: new FormControl(),
    prescription: new FormControl(),
  });

  ngOnInit(): void {
    this.approvedAppointments();
  }

  public approvedAppointments(){
    this.doctorService.approvedAppointments().subscribe(
      (response:any)=>{
        this.appointment=response.appointmentList;
      },
      (error)=>{
        console.log(error);
      }
    );
  }

  public patientDetails(id:string){
    this.doctorService.appointmentDetails(id).subscribe(
      (response:any)=>{
        console.log(response);
        this.appointmentId = response.data.appointmentId;
        this.patientName = response.data.patientName;
        this.symptom = response.data.symptom;
        this.medication =response.data.medication;
         
      },
      (error)=>{
        console.log(error);
      }
    );
  }

  public visited(id:string){
    this.doctorService.visited(id).subscribe(
      (response:any)=>{
        console.log(response);
        this.approvedAppointments();
      },
      (error)=>{
        console.log(error);
      }
    );

  }

  public prescribe( ) {
    console.log(this.prescriptionForm.value);
    this.doctorService.prescribe(this.prescriptionForm.value).subscribe(
      (response:any)=>{
        console.log(response.message);
        this.modalClose.nativeElement.click();
        this.approvedAppointments();
      },
      (error)=>{
        console.log(error);
      }
    );
  }

  public appointId(id:string){
    this. prescriptionForm = new FormGroup({
      appointmentId : new FormControl(id),
      diesis: new FormControl(),
      prescription: new FormControl(),
    });
  }


  public appointFullDetails(id:string){
    this.doctorService.appointmentDetails(id).subscribe(
      (response:any)=>{
        console.log(response);
        this.appointmentId = response.data.appointmentId;
        this.patientName = response.data.patientName;
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
