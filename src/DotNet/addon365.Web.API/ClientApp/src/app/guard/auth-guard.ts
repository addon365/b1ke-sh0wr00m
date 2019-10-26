import { CanActivate, Router } from "@angular/router";
import { UserService } from "../services/user.service";
import { Injectable } from "@angular/core";
@Injectable()
export class AuthGuard implements CanActivate {
  constructor(public auth: UserService, public router: Router) {}
  canActivate(): boolean {
    if (!this.auth.isAuthenticated()) {
      this.router.navigate(["/login"]);
      return false;
    }

    return true;
  }
}
