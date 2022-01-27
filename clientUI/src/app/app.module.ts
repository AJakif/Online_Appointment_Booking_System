import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { PatientComponent } from './patient/patient.component';
import { LoginComponent } from './login/login.component';
import { HeaderComponent } from './header/header.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { RegisterComponent } from './register/register.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';
import { AuthGuard } from './_auth/auth.guard';
import { AuthInterceptor } from './_auth/auth.interceptor';
import { UserService } from './_services/user.service';
import { DoctorComponent } from './doctor/doctor.component';
import { SecretaryComponent } from './secretary/secretary.component';
import { SmallCardComponent } from './components/small-card/small-card.component';
import { AddDoctorComponent } from './admin/add-doctor/add-doctor.component';
import { AddPatientComponent } from './admin/add-patient/add-patient.component';
import { AddSpecializationComponent } from './admin/add-specialization/add-specialization.component';
import { GetAllDoctorComponent } from './admin/get-all-doctor/get-all-doctor.component';
import { GetAllPatientComponent } from './admin/get-all-patient/get-all-patient.component';
import { GetAllSpecializationComponent } from './admin/get-all-specialization/get-all-specialization.component';
import { RouteButtonComponent } from './components/route-button/route-button.component';
import { GetAllPendinAppointmentComponent } from './secretary/get-all-pendin-appointment/get-all-pendin-appointment.component';
import { AppointmentComponent } from './patient/appointment/appointment.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AdminComponent,
    PatientComponent,
    LoginComponent,
    HeaderComponent,
    ForbiddenComponent,
    RegisterComponent,
    FooterComponent,
    DoctorComponent,
    SecretaryComponent,
    SmallCardComponent,
    AddDoctorComponent,
    AddPatientComponent,
    AddSpecializationComponent,
    GetAllDoctorComponent,
    GetAllPatientComponent,
    GetAllSpecializationComponent,
    RouteButtonComponent,
    GetAllPendinAppointmentComponent,
    AppointmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass:AuthInterceptor,
      multi:true
    },
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
