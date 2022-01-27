import { Component, OnInit } from '@angular/core';
import { AdminApiService } from '../_services/admin-api.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  patientCount!:number;
  DoctorCount!:number;
  specialCount!:number;
  balance!:number;

  constructor(private adminService : AdminApiService) { }

  ngOnInit(): void {
    this.showPatientCounts();
    this.showDoctorCounts();
    this.showSpecializationCounts();
    this.showBalance();

  }


  public showPatientCounts()
  {
    this.adminService.patients().subscribe(
      (response:any)=>{
        this.patientCount = response.patient
      },
      (error)=>{
        console.log(error);
      }
    );
    
  }
  public showDoctorCounts()
  {
    this.adminService.doctors().subscribe(
      (response:any)=>{
        this.DoctorCount = response.doctor
      },
      (error)=>{
        console.log(error);
      }
    );
    
  }
  public showSpecializationCounts()
  {
    this.adminService.specializations().subscribe(
      (response:any)=>{
        this.specialCount = response.special
      },
      (error)=>{
        console.log(error);
      }
    );
    
  }
  public showBalance()
  {
    this.adminService.balance().subscribe(
      (response:any)=>{
        console.log(response)
        this.balance = response.balance
      },
      (error)=>{
        console.log(error);
      }
    );
    
  }
}
