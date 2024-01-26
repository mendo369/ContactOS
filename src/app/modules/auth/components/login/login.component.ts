import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  formLogin: FormGroup;

  constructor(private authService: AuthService) {
    this.formLogin = new FormGroup({
      phone: new FormControl(),
      password: new FormControl(),
    });
  }

  async onSubmit() {
    this.authService.login(this.formLogin.value);
    // alert(response);
  }
}
