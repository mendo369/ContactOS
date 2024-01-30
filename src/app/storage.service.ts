import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class StorageService {
  constructor(private router: Router) {}

  // Obtener un elemento del Local Storage
  getItem(key: string): any {
    const item = localStorage.getItem(key);
    return item ? JSON.parse(item) : null;
  }

  getToken(): string {
    const user = this.getItem('user');
    const token = user.token;
    return token ? token : '';
  }

  // Guardar un elemento en el Local Storage
  setItem(key: string, value: any): void {
    localStorage.setItem(key, JSON.stringify(value));
  }

  // Eliminar un elemento del Local Storage
  removeItem(key: string): void {
    localStorage.removeItem(key);
  }

  // Limpiar todo el Local Storage
  clearStorage(): void {
    localStorage.clear();
    this.router.navigate(['/auth/login']);
  }
}
