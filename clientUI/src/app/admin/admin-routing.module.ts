import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../_auth/auth.guard';
import { AddDoctorComponent } from './add-doctor/add-doctor.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { AddSpecializationComponent } from './add-specialization/add-specialization.component';
import { AdminComponent } from './dashboard/admin.component';
import { GetAllDoctorComponent } from './get-all-doctor/get-all-doctor.component';
import { GetAllPatientComponent } from './get-all-patient/get-all-patient.component';
import { GetAllSpecializationComponent } from './get-all-specialization/get-all-specialization.component';

const routes: Routes = [
      {
        path: 'dashboard',
        component: AdminComponent,
        canActivate: [AuthGuard],
        data: { roles: 'Admin' },
      },
      {
        path: 'getAllDoctor',
        component: GetAllDoctorComponent,
        canActivate: [AuthGuard],
        data: { roles: 'Admin' },
      },
      {
        path: 'addDoctor',
        component: AddDoctorComponent,
        canActivate: [AuthGuard],
        data: { roles: 'Admin' },
      },
      {
        path: 'getAllPatient',
        component: GetAllPatientComponent,
        canActivate: [AuthGuard],
        data: { roles: 'Admin' },
      },
      {
        path: 'addPatient',
        component: AddPatientComponent,
        canActivate: [AuthGuard],
        data: { roles: 'Admin' },
      },
      {
        path: 'getAllSpecialization',
        component: GetAllSpecializationComponent,
        canActivate: [AuthGuard],
        data: { roles: 'Admin' },
      },
      {
        path: 'addSpecialization',
        component: AddSpecializationComponent,
        canActivate: [AuthGuard],
        data: { roles: 'Admin' },
      }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
