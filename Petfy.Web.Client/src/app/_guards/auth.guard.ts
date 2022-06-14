import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../_services/auth.service';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private auth: AuthService, private router: Router){}
  
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
    // this.auth.currentUser$.pipe(
    //   map((response: User) => {
    //     const user = response;
    //     if(user){
    //       return true;
    //     }
    //   })
    // );
    if(this.auth.loggedIn())
      return true;
    this.auth.logout();
    this.router.navigate(['/login']);
    return false;
  }
  
}
