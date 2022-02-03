import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserAuthService } from '../../_services/user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminApiService {

  constructor(private httpclient: HttpClient,
    private userAuthServise : UserAuthService) { }

  PATH_OF_API = "https://localhost:44388/api";
  token = this.userAuthServise.getToken();
   requestHeader = new HttpHeaders(
     {Authorization:  `${this.token}`}
   );


   public patients(){
    return this.httpclient.get(this.PATH_OF_API + "/admin/CountPatient", {headers:this.requestHeader});
  }
  public doctors(){
    return this.httpclient.get(this.PATH_OF_API + "/admin/CountDoctor", {headers:this.requestHeader});
  }
  public specializations(){
    return this.httpclient.get(this.PATH_OF_API + "/admin/CountSpecialization", {headers:this.requestHeader});
  }
  public balance(){
    return this.httpclient.get(this.PATH_OF_API + "/admin/Balance", {headers:this.requestHeader});
  }
  public getPatients(){
    return this.httpclient.get(this.PATH_OF_API + "/admin/GetAllPatient", {headers:this.requestHeader});
  }
  public getDoctors(){
    return this.httpclient.get(this.PATH_OF_API + "/admin/GetAllDoctor", {headers:this.requestHeader});
  }
  public getSpecialization(){
    return this.httpclient.get(this.PATH_OF_API + "/admin/GetAllSpecialization", {headers:this.requestHeader});
  }
  public monthlyDeposit(){
    return this.httpclient.get(this.PATH_OF_API + "/admin/Report/monthlyDeposit", {headers:this.requestHeader});
  }
  public yearlyDeposit(){
    return this.httpclient.get(this.PATH_OF_API + "/admin/Report/yearlyDeposit", {headers:this.requestHeader});
  }
}
