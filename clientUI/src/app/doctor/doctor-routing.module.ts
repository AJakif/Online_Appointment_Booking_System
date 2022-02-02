import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../_auth/auth.guard';
import { DoctorComponent } from './dashboard/doctor.component';

const routes: Routes = [
      {path:"dashboard",component:DoctorComponent, canActivate:[AuthGuard], data:{roles:'Doctor'}}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
