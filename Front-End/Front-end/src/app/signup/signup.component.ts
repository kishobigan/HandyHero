import { Component } from '@angular/core';
import {NgStyle} from "@angular/common";
import {RouterLink, RouterLinkActive} from "@angular/router";

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [
    NgStyle,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  backGroundImage = 'assets/images/main_background.png'
}
