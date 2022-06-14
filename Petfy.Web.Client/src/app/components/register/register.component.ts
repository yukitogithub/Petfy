import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  constructor(
    private auth: AuthService, 
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  submitRegister(){
    const register = this.registerForm.value;
    if(this.registerForm.valid) {
      this.auth.register(register).subscribe({
        //next (paso exitoso)
        next: user => this.router.navigate(['/']),
        //nombre | (nombre) | () => { line1; line2 }
        //error (paso erroneo)
        error: error => console.log(error),
        //complete (paso sí o sí)
        complete: () => console.log("complete")
      });
    }

  }
}
