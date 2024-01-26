import { Injectable } from '@angular/core';
import { StorageService } from '../../storage.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NotesService {
  private baseUrl: string;
  private token: string;
  constructor(
    private strorageService: StorageService,
    private http: HttpClient
  ) {
    this.baseUrl = 'http://localhost:5035/api/Notes';
    this.token = strorageService.getToken();
  }

  getNotes(): Observable<any> {
    const headers = new HttpHeaders({
      Authorization: `Bearer ${this.token}`, // Add the authentication header
    });

    return this.http.get<any>(this.baseUrl, { headers });
  }
}
