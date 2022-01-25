import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { DoctorComponent } from './doctor/doctor.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PatientComponent } from './patient/patient.component';
import { RegisterComponent } from './register/register.component';
import { SecretaryComponent } from './secretary/secretary.component';
import { AuthGuard } from './_auth/auth.guard';

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"admin/dashboard",component:AdminComponent, canActivate:[AuthGuard], data:{roles:'Admin'}},
  {path:"patient/dashboard",component:PatientComponent, canActivate:[AuthGuard], data:{roles:'Patient'}},
  {path:"doctor/dashboard",component:DoctorComponent, canActivate:[AuthGuard], data:{roles:'Doctor'}},
  {path:"secretary/dashboard",component:SecretaryComponent, canActivate:[AuthGuard], data:{roles:'Secretary'}},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"forbidden",component:ForbiddenComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
