import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../_auth/auth.guard';
import { SecretaryComponent } from './dashboard/secretary.component';
import { GetAllPendinAppointmentComponent } from './get-all-pendin-appointment/get-all-pendin-appointment.component';

const routes: Routes = [
      {path:"dashboard",component:SecretaryComponent, canActivate:[AuthGuard], data:{roles:'Secretary'}},
      {path:"getAllPendingAppointment",component:GetAllPendinAppointmentComponent, canActivate:[AuthGuard], data:{roles:'Secretary'}}  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecretaryRoutingModule { }
