import { Component, OnInit } from '@angular/core';
import { SecretaryApiService } from 'src/app/_services/secretary-api.service';

@Component({
  selector: 'app-get-all-pendin-appointment',
  templateUrl: './get-all-pendin-appointment.component.html',
  styleUrls: ['./get-all-pendin-appointment.component.css']
})
export class GetAllPendinAppointmentComponent implements OnInit {

  appointment!:any;
  constructor(private secretaryService: SecretaryApiService) { }

  ngOnInit(): void {
    this.showPendingApp();
    
  }

  public showPendingApp(){
    this.secretaryService.pendingAppointments().subscribe(
      (response:any)=>{
        console.log("lenght "+response.appointmentList.length)
        
        this.appointment = response.appointmentList;
        
      },
      (error)=>{
        console.log(error);
      }
    );
  }


 public approve(appointId:string){

  this.secretaryService.approveAppointment(appointId).subscribe(
    (response:any)=>{
      console.log(response);
      this.showPendingApp();
    },
    (error)=>{
      console.log(error);
    }
    );
 }

 public decline(appointId:string){

  this.secretaryService.declineAppointment(appointId).subscribe(
    (response:any)=>{
      console.log(response);
      this.showPendingApp();
    },
    (error)=>{
      console.log(error);
    }
    );
 }

}
