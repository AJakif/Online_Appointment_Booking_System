import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatientApiService } from '../_services/patient-api.service';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {

  appointment:any = null;
  constructor(
    private patientService : PatientApiService,
    private router: Router
  ) { }

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

}
