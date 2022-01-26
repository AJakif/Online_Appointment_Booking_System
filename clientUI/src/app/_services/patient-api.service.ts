import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserAuthService } from './user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class PatientApiService {

  constructor(private httpclient: HttpClient,
    private userAuthServise : UserAuthService) { }

    
  PATH_OF_API = "https://localhost:44388/api";
  token = this.userAuthServise.getToken();
   requestHeader = new HttpHeaders(
     {Authorization:  `${this.token}`}
   );

  //  requestHeader = new HttpHeaders(
  //   {"No-Auth":"False"}
  // );

  public specializations(){
    return this.httpclient.get(this.PATH_OF_API + "/patient/specialization/all", {headers:this.requestHeader});
  }
  
  public doctor(id:number){
    return this.httpclient.get(this.PATH_OF_API + `/patient/getdoctor/${id}`, {headers:this.requestHeader});
  }

  public appointment(appData:any){
    return this.httpclient.post(this.PATH_OF_API + "/patient/giveAppoinment", appData , {headers:this.requestHeader});
  }

  public appointments(){
    return this.httpclient.get(this.PATH_OF_API + "/patient/appointments", {headers:this.requestHeader});
  }
}