import { Component, OnInit } from '@angular/core';
import { AdminApiService } from '../_services/admin-api.service';

@Component({
  selector: 'app-get-all-patient',
  templateUrl: './get-all-patient.component.html',
  styleUrls: ['./get-all-patient.component.css']
})
export class GetAllPatientComponent implements OnInit {

  patients!:any;
  constructor(private adminService:AdminApiService) { }

  ngOnInit(): void {
    this.AllPatients();
  }

  public AllPatients(){
    this.adminService.getPatients().subscribe(
      (response:any)=>{
        console.log(response)
        this.patients=response.data;
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
