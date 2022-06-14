import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  user: any = {};
  //currentUser$: Observable<User>;

  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    //this.currentUser$ = this.authService.currentUser$;
  }

  login(){
    console.log(this.user);
    this.authService.login(this.user).subscribe({
      //next (paso exitoso)
      next: user => { console.log(user) },
      //nombre | (nombre) | () => { line1; line2 }
      //error (paso erroneo)
      error: error => console.log(error),
      //complete (paso sí o sí)
      complete: () => console.log("complete")
    });
  }

  logout(){
    this.authService.logout();
    this.router.navigate(['/login']);
  }

}
