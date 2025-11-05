import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetUserCompaniesResponse } from '../../model/getUserCompaniesResponse';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  private baseUrl = 'https://localhost:7233/api'; // update if needed

  constructor(private http: HttpClient) { }

  getUserCompanies(userId: number): Observable<GetUserCompaniesResponse> {
    const url = `${this.baseUrl}/Members/Member/${userId}/Companies`;
    return this.http.get<GetUserCompaniesResponse>(url);
  }
}
