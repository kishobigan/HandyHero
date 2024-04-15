import { Injectable } from '@angular/core';
import {HttpClient, HttpResponse} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class MakeComplaintService {

  private baseUrl = "https://localhost:7174/api/";

  constructor(private http: HttpClient) { }

  makeComplaint(complainant:number, accused:string, message:string): Observable<HttpResponse<any>>{
    let complaintData = {complainant, accused, message}
    return this.http.post(`${this.baseUrl}Customer/complaint`, complaintData, { observe: 'response' })

  }

  getAllComplaint() {

  }
}
