import { Component, OnInit } from '@angular/core';
import { AdminApiService } from '../_services/admin-api.service';

@Component({
  selector: 'app-get-all-specialization',
  templateUrl: './get-all-specialization.component.html',
  styleUrls: ['./get-all-specialization.component.css']
})
export class GetAllSpecializationComponent implements OnInit {

  specializations!: any;
  constructor(private adminService : AdminApiService) { }

  ngOnInit(): void {
    this.AllSpecializations();
  }

  public AllSpecializations(){
    this.adminService.getSpecialization().subscribe(
      (response:any)=>{
        this.specializations=response.data;
      },
      (error)=>{
        console.log(error);
      }
    );
  }
}
