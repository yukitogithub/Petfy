import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(
    private auth: AuthService, 
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    })
    /*
    {
      username: '',
      password: ''
    }
    */
  }

  submitLogin(){
    var route = this.router;
    if(this.loginForm.valid){
      console.log(this.loginForm.value);
      this.auth.login(this.loginForm.value).subscribe({
        //next (paso exitoso)
        next: (user) => route.navigate(['/']),
        //nombre | (nombre) | () => { line1; line2 }
        //error (paso erroneo)
        error: (error) => { console.log(error); },
        //complete (paso sí o sí)
        complete: () => console.log("complete")
      });
    }
  }
}
