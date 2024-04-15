import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class FindWorkerService {
  private baseUrl = "https://localhost:7174/api/";
  constructor(private http: HttpClient) { }

  getAllWorkers(){
    return this.http.get<any[]>(`${this.baseUrl}Admin/fieldWorkers`)
  }
}
