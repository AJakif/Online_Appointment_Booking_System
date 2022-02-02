import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecretaryRoutingModule } from './secretary-routing.module';
import { SecretaryComponent } from './dashboard/secretary.component';
import { GetAllPendinAppointmentComponent } from './get-all-pendin-appointment/get-all-pendin-appointment.component';
import { SmallCardComponent } from './components/small-card/small-card.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    SecretaryComponent,
    GetAllPendinAppointmentComponent,
    SmallCardComponent
  ],
  imports: [
    CommonModule,
    SecretaryRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule
  ]
})
export class SecretaryModule { }
