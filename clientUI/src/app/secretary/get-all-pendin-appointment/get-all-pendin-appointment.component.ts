import { Component, OnInit } from '@angular/core';
import { SecretaryApiService } from 'src/app/_services/secretary-api.service';

@Component({
  selector: 'app-get-all-pendin-appointment',
  templateUrl: './get-all-pendin-appointment.component.html',
  styleUrls: ['./get-all-pendin-appointment.component.css']
})
export class GetAllPendinAppointmentComponent implements OnInit {

  appointment:any = null;
  constructor(private secretaryService: SecretaryApiService) { }

  ngOnInit(): void {

    this.secretaryService.pendingAppointments().subscribe(
      (response:any)=>{
        console.log(response.appointmentList.length)
        if(response.appointmentList.length === 0)
        {
          this.appointment = null
        }
        else{
          this.appointment = response.appointmentList;
        }
        
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
