import { Component, OnInit } from '@angular/core';
import { SecretaryApiService } from '../_services/secretary-api.service';

@Component({
  selector: 'app-secretary',
  templateUrl: './secretary.component.html',
  styleUrls: ['./secretary.component.css']
})
export class SecretaryComponent implements OnInit {

  appointment:any;
  count!: number;
  constructor(private secretaryService:SecretaryApiService) { }

  ngOnInit(): void {
    this.showPendingAppointmentCounts();
    this.approvedAppointments();
  }

  public showPendingAppointmentCounts()
  {
    this.secretaryService.pendingAppointmentCounts().subscribe(
      (response:any)=>{
        this.count = response.appointment
      },
      (error)=>{
        console.log(error);
      }
    );
    
  }

  public approvedAppointments(){
    this.secretaryService.approvedAppointments().subscribe(
      (response:any)=>{
        this.appointment=response.appointmentList;
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
