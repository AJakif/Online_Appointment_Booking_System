import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_auth/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'admin',
    loadChildren: () =>
      import('./admin/admin.module').then((mod) => mod.AdminModule),
  },
  {
    path: 'doctor',
    loadChildren: () =>
      import('./doctor/doctor.module').then((mod) => mod.DoctorModule),
  },
  {
    path: 'secretary',
    loadChildren: () =>
      import('./secretary/secretary.module').then((mod) => mod.SecretaryModule),
  },
  {
    path: 'patient',
    loadChildren: () =>
      import('./patient/patient.module').then((mod) => mod.PatientModule),
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'forbidden', component: ForbiddenComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
