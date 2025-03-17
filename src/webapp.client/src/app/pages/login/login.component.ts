import { Component, inject } from '@angular/core';
import { AuthService } from '../../shared/services/auth.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { User } from '../../shared/models/user.model';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { DividerModule } from 'primeng/divider';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, InputTextModule, PasswordModule, ButtonModule ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  private authService: AuthService = inject(AuthService);
  private formBuilder: FormBuilder = inject(FormBuilder);

  form = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(8), Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$/)]], // Source: https://stackoverflow.com/questions/48635152/regex-for-default-asp-net-core-identity-password
  });

  onSubmit() {
    if (this.form.invalid) {
      alert('Please fill in all fields correctly.');
      return;
    }

    const loginRequest: Observable<any> = this.authService.login({
      email: this.form.value.email,
      password: this.form.value.password
    } as User)

    loginRequest.subscribe({
      next: () => {
        this.form.reset();
        alert('Login successful');
      },
      error: error => {
        alert('Login failed');
        console.error('Login error: ', error);
      }
    });
  }
}
