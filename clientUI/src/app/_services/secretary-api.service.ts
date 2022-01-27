import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserAuthService } from './user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class SecretaryApiService {

  constructor(private httpclient: HttpClient,
    private userAuthServise : UserAuthService) { }

  PATH_OF_API = "https://localhost:44388/api";
  token = this.userAuthServise.getToken();
   requestHeader = new HttpHeaders(
     {Authorization:  `${this.token}`}
   );


   public pendingAppointments(){
    return this.httpclient.get(this.PATH_OF_API + "/secretary/pendingAppointments", {headers:this.requestHeader});
  }

  public approvedAppointments(){
    return this.httpclient.get(this.PATH_OF_API + "/secretary/approvedAppointments", {headers:this.requestHeader});
  }

  public pendingAppointmentCounts(){
    return this.httpclient.get(this.PATH_OF_API + "/secretary/CountPendingAppointment", {headers:this.requestHeader});
  }

  public approveAppointment(id:string){
    return this.httpclient.post(this.PATH_OF_API + `/secretary/appointment/Approve/${id}`, {headers:this.requestHeader});
  }

  public declineAppointment(id:string){
    return this.httpclient.post(this.PATH_OF_API + `/secretary/appointment/Decline/${id}`, {headers:this.requestHeader});
  }
}
