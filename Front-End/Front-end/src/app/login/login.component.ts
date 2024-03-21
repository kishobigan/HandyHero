import {Component, ViewChild} from '@angular/core';
import {NgStyle} from "@angular/common";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {FormsModule, NgForm} from "@angular/forms";
import {isEmpty} from "rxjs";


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    NgStyle,
    RouterLink,
    RouterLinkActive,
    FormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  @ViewChild("loginForm") loginForm!: NgForm

  backGroundImage = 'assets/images/main_background.png'
  emailError = "";
  passwordError = "";

  isEmpty(text : any){
    return text.trim() == '';
  }
  isEmail(email:string): boolean {
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailRegex.test(email);
  }

  login()
  {
    const formData = this.loginForm.value;
    let email = formData.email;
    let password = formData.password;

    if (this.isEmpty(email)){
      this.emailError = "Email field should not be empty";
    }else if(!this.isEmail(email)){
      this.emailError = "Please enter a valid email";
    }else if (this.isEmpty(password)){
      this.passwordError = "password field should not be empty";
    }else {
      this.emailError = "";
      this.passwordError = "";
      console.log("Email : " + email);
      console.log("Password : " + password);
    }

  }
}
