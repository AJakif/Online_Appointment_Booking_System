import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDoctorComponent } from './admin/add-doctor/add-doctor.component';
import { AddPatientComponent } from './admin/add-patient/add-patient.component';
import { AddSpecializationComponent } from './admin/add-specialization/add-specialization.component';
import { AdminComponent } from './admin/admin.component';
import { GetAllDoctorComponent } from './admin/get-all-doctor/get-all-doctor.component';
import { GetAllPatientComponent } from './admin/get-all-patient/get-all-patient.component';
import { GetAllSpecializationComponent } from './admin/get-all-specialization/get-all-specialization.component';
import { DoctorComponent } from './doctor/doctor.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AppointmentComponent } from './patient/appointment/appointment.component';
import { PatientComponent } from './patient/patient.component';
import { RegisterComponent } from './register/register.component';
import { GetAllPendinAppointmentComponent } from './secretary/get-all-pendin-appointment/get-all-pendin-appointment.component';
import { SecretaryComponent } from './secretary/secretary.component';
import { AuthGuard } from './_auth/auth.guard';

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"admin/dashboard",component:AdminComponent, canActivate:[AuthGuard], data:{roles:'Admin'}},
  {path:"admin/getAllDoctor",component:GetAllDoctorComponent, canActivate:[AuthGuard], data:{roles:'Admin'}},
  {path:"admin/addDoctor",component:AddDoctorComponent, canActivate:[AuthGuard], data:{roles:'Admin'}},
  {path:"admin/getAllPatient",component:GetAllPatientComponent, canActivate:[AuthGuard], data:{roles:'Admin'}},
  {path:"admin/addPatient",component:AddPatientComponent, canActivate:[AuthGuard], data:{roles:'Admin'}},
  {path:"admin/getAllSpecialization",component:GetAllSpecializationComponent, canActivate:[AuthGuard], data:{roles:'Admin'}},
  {path:"admin/addSpecialization",component:AddSpecializationComponent, canActivate:[AuthGuard], data:{roles:'Admin'}},
  {path:"patient/dashboard",component:PatientComponent, canActivate:[AuthGuard], data:{roles:'Patient'}},
  {path:"patient/appointment",component:AppointmentComponent, canActivate:[AuthGuard], data:{roles:'Patient'}},
  {path:"doctor/dashboard",component:DoctorComponent, canActivate:[AuthGuard], data:{roles:'Doctor'}},
  {path:"secretary/dashboard",component:SecretaryComponent, canActivate:[AuthGuard], data:{roles:'Secretary'}},
  {path:"secretary/getAllPendingAppointment",component:GetAllPendinAppointmentComponent, canActivate:[AuthGuard], data:{roles:'Secretary'}},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"forbidden",component:ForbiddenComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
