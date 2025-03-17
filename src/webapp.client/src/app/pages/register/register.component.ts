import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../shared/services/auth.service';
import { Observable } from 'rxjs';
import { User } from '../../shared/models/user.model';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { DividerModule } from 'primeng/divider';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, InputTextModule, PasswordModule, ButtonModule, DividerModule ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  formBuilder: FormBuilder = inject(FormBuilder);
  authService: AuthService = inject(AuthService);

  form = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(8), Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$/)]],
  });

  onSubmit() {
    if (this.form.invalid) {
      alert('Please fill in all fields correctly.');
      return;
    }

    const registerRequest: Observable<any> = this.authService.register({
      email: this.form.value.email,
      password: this.form.value.password
    } as User)

    registerRequest.subscribe({
      next: () => {
        this.form.reset();
        alert('Registration successful');
      },
      error: error => {
        alert("Registration failed.");
        console.error('Registration error: ', error);
      }
    });
  }

  logout() {
    this.authService.logout();
  }

}
