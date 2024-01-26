import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthService } from '../../auth.service';

@Component({
  // standalone: true,
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  formRegister: FormGroup;

  constructor(private authService: AuthService) {
    this.formRegister = new FormGroup({
      name: new FormControl(),
      lastName: new FormControl(),
      phone: new FormControl(),
      password: new FormControl(),
    });
  }

  async onSubmit() {
    const response = await this.authService.register(this.formRegister.value);

    console.warn(response);
  }
}
