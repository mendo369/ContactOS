import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = 'http://localhost:5035/api/Auth';
  }

  register(formValue: any) {
    return firstValueFrom(
      this.http.post<any>(`${this.baseUrl}/register`, formValue)
    ).then((res) => {
      if (res.status) {
        const login = this.login(formValue).then((res) => res);
        return login;
      }
      return false;
    });
  }

  login(formValue: any) {
    return firstValueFrom(
      this.http.post<any>(`${this.baseUrl}/login`, formValue)
    ).then((res) => {
      if (res.status) {
        localStorage.setItem('user', JSON.stringify(res.value));
        return true;
      }
      return false;
    });
  }
}
