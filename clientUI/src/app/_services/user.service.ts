import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserAuthService } from './user-auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  PATH_OF_API = "https://localhost:44388/api";

  requestHeader = new HttpHeaders(
    {"No-Auth":"True"}
  );
  constructor(
    private httpclient: HttpClient,
    private userAuth:UserAuthService
    ) { }

  public login(loginData:any){
    return this.httpclient.post(this.PATH_OF_API + "/login", loginData, {headers:this.requestHeader});
  }

  public resigtration(regData:any){
    return this.httpclient.post(this.PATH_OF_API + "/register", regData, {headers:this.requestHeader});
  }

  public roleMatch(allowedRole:string): boolean{
    let isMatch = false;
    const role = this.userAuth.getRole();

    if(role != null && role){
      if(role === allowedRole){
        isMatch = true;
        return isMatch;
      }
      else{
        return isMatch;
      }
    }
    return isMatch;
  }
}
