import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, Observable, of } from 'rxjs';
import { AccountService } from '../services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService: AccountService,
    private router: Router){}
    canActivate(): Observable<boolean> {
      if(this.accountService.currentUserSource  instanceof Observable){
       this.router.navigateByUrl('/passport/login');
       return of(false);
      }
      return of(true);
  }
}
