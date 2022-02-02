import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserAuthService } from '../../_services/user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class DoctorApiService {

  constructor(private httpclient: HttpClient,
    private userAuthServise : UserAuthService) { }

  PATH_OF_API = "https://localhost:44388/api";
  token = this.userAuthServise.getToken();
   requestHeader = new HttpHeaders(
     {Authorization:  `${this.token}`}
   );

  public approvedAppointments(){
    return this.httpclient.get(this.PATH_OF_API + "/doctor/getApprovedAppointmnets", {headers:this.requestHeader});
  }

  public appointmentDetails(id:string){
    return this.httpclient.get(this.PATH_OF_API + `/doctor/appointment/patient/${id}`, {headers:this.requestHeader});
  }

  public visited (id:string){
    return this.httpclient.get(this.PATH_OF_API + `/doctor/appointment/visit/${id}`, {headers:this.requestHeader});
  }

  public prescribe(data:any){
    return this.httpclient.post(this.PATH_OF_API + "/doctor/givePrescription", data , {headers:this.requestHeader});
  }

}
