import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../_auth/auth.guard';
import { AppointmentComponent } from './appointment/appointment.component';
import { PatientComponent } from './dashboard/patient.component';

const routes: Routes = [
      {path:"dashboard",component:PatientComponent, canActivate:[AuthGuard], data:{roles:'Patient'}},
      {path:"appointment",component:AppointmentComponent, canActivate:[AuthGuard], data:{roles:'Patient'}}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientRoutingModule { }
