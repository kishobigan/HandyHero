import { Routes } from '@angular/router';
import {LoginComponent} from "./login/login.component";
import {SignupComponent} from "./signup/signup.component";
import {LandingComponent} from "./landing/landing.component";
import {AuthLayoutComponent} from "./auth-layout/auth-layout.component"
import {OTPVerificationComponent} from "./otpverification/otpverification.component";

export const routes: Routes = [
  {
    path:'auth',
    component: AuthLayoutComponent,
    children: [
      {path:'login', component: LoginComponent},
      {path: 'signup', component: SignupComponent},
      {path: 'OTP-Verification', component:OTPVerificationComponent}
    ]
  },
  {path:'', component:LandingComponent, pathMatch:'full'},
  {path:'**',component:LoginComponent}
];
