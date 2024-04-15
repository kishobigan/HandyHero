import { Routes } from '@angular/router';
import {LoginComponent} from "./login/login.component";
import {SignupComponent} from "./signup/signup.component";
import {LandingComponent} from "./landing/landing.component";
import {AuthLayoutComponent} from "./auth-layout/auth-layout.component"
import {OTPVerificationComponent} from "./otpverification/otpverification.component";
import {DashboardLayoutComponent} from "./dashboard-layout/dashboard-layout.component";
import {ProjectsComponent} from "./customer/projects/projects.component";
import {FindComponent} from "./customer/find/find.component";
import {ChatComponent} from "./chat/chat.component";
import {ComplaintComponent} from "./complaint/complaint.component";
import {RouteGuard} from "../Common/RouteGuard";

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
  {
    path:'dashboard',
    component: DashboardLayoutComponent,
    canActivate: [RouteGuard],
    children: [
      {path: 'projects', component: ProjectsComponent},
      {path: 'find', component: FindComponent},
      {path:'chat', component: ChatComponent},
      {path: 'complaint', component: ComplaintComponent}
    ]
  },
  {path:'', component:LandingComponent, pathMatch:'full'},
  {path:'**',component:LoginComponent}
];
