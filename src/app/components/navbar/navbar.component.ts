import { Component } from '@angular/core';
import { StorageService } from '../../storage.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
})
export class NavbarComponent {
  constructor(private storageService: StorageService) {}

  user = this.storageService.getItem('user');
}
