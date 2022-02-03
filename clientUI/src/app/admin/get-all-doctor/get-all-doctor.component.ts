import { Component, OnInit } from '@angular/core';
import { AdminApiService } from '../_services/admin-api.service';

@Component({
  selector: 'app-get-all-doctor',
  templateUrl: './get-all-doctor.component.html',
  styleUrls: ['./get-all-doctor.component.css']
})
export class GetAllDoctorComponent implements OnInit {

  doctors!: any;
  constructor(private adminService : AdminApiService) { }

  ngOnInit(): void {
    this.AllDoctors();
  }

  public AllDoctors(){
    this.adminService.getDoctors().subscribe(
      (response:any)=>{
        this.doctors=response.data;
      },
      (error)=>{
        console.log(error);
      }
    );
  }

}
