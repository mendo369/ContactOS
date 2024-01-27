import { Injectable } from '@angular/core';
import { StorageService } from '../../storage.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ContactsService {
  private baseUrl: string;
  private token: string;
  constructor(
    private strorageService: StorageService,
    private http: HttpClient
  ) {
    this.baseUrl = 'http://localhost:5035/api/Contacts';
    this.token = strorageService.getToken();
  }

  getContacts(): Observable<any> {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${this.token}`, // Add the authentication header
    });

    return this.http.get<any>(this.baseUrl, { headers });
  }

  create(formValue: any) {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${this.token}`, // Add the authentication header
    });

    return this.http.post<any>(this.baseUrl, formValue, { headers });
  }
}
