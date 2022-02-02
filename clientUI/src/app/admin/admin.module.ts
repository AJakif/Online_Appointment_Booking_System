import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AddDoctorComponent } from './add-doctor/add-doctor.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { AddSpecializationComponent } from './add-specialization/add-specialization.component';
import { AdminComponent } from './dashboard/admin.component';
import { GetAllDoctorComponent } from './get-all-doctor/get-all-doctor.component';
import { GetAllPatientComponent } from './get-all-patient/get-all-patient.component';
import { GetAllSpecializationComponent } from './get-all-specialization/get-all-specialization.component';
import { SmallCardComponent } from './components/small-card/small-card.component';
import { RouteButtonComponent } from './components/route-button/route-button.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HighchartsChartComponent, HighchartsChartModule } from 'highcharts-angular';
console.warn("admin module")
@NgModule({
  declarations: [
    AddDoctorComponent,
    AddPatientComponent,
    AddSpecializationComponent,
    AdminComponent,
    GetAllDoctorComponent,
    GetAllPatientComponent,
    GetAllSpecializationComponent,
    SmallCardComponent,
    RouteButtonComponent
    
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule,
    HighchartsChartModule
  ]
})
export class AdminModule { }
