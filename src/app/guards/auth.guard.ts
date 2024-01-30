import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from '../storage.service';

export const authGuard = () => {
  const router = inject(Router);

  const storage = inject(StorageService);
  const user = storage.getItem('user');
  console.warn(user);

  if (user == null) {
    router.navigate(['/auth/login']);
    return false; // Usuario autenticado, permite la navegación
  }
  return true;
};

// import { Injectable } from '@angular/core';
// import {
//   CanActivate,
//   ActivatedRouteSnapshot,
//   RouterStateSnapshot,
//   Router,
// } from '@angular/router';
// import { StorageService } from '../storage.service';

// @Injectable({
//   providedIn: 'root',
// })
// export class authGuard implements CanActivate {
//   constructor(private storageService: StorageService, private router: Router) {}

//   canActivate(
//     route: ActivatedRouteSnapshot,
//     state: RouterStateSnapshot
//   ): boolean {
//     alert('hola');
//     const user = this.storageService.getItem('user'); // Asegúrate de tener un método getUser() en tu servicio

//     if (user !== null && user !== undefined) {
//       alert(true);
//       return true; // Usuario autenticado, permite la navegación
//     } else {
//       alert('hey');
//       this.router.navigate(['/auth/login']);
//       return false;
//     }
//   }
// }
