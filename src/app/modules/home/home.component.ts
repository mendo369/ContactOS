import { Component } from '@angular/core';
import { StorageService } from '../../storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  constructor(private storageService: StorageService, private router: Router) {}

  ngOnInit(): void {
    const user = this.storageService.getItem('user');

    if (user == null) {
      this.router.navigate(['/auth/login']);
    }
  }
}
