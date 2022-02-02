import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { AppointmentComponent } from './appointment/appointment.component';
import { PatientComponent } from './dashboard/patient.component';
import { SmallCardComponent } from './components/small-card/small-card.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    AppointmentComponent,
    PatientComponent,
    SmallCardComponent
  ],
  imports: [
    CommonModule,
    PatientRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule
  ]
})
export class PatientModule { }
