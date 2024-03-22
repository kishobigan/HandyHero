import {Component} from '@angular/core';
import {NgForOf, NgIf, NgStyle} from "@angular/common";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [
    NgStyle,
    RouterLink,
    RouterLinkActive,
    NgIf,
    FormsModule,
    NgForOf
  ],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {

  buttonText = "Sign Up"

  name = "";
  email = '';
  phoneNumber = '';
  password = '';
  confirmPassword = '';
  role = '';

  dob = '';
  workType = '';

  nameError = '';
  emailError = '';
  phoneNumberError = '';
  passwordError = '';
  confirmPasswordError = '';
  roleError = '';

  dobError = '';
  workTypeError = '';


  isEmpty(text: any) {
    return text.trim() == '';
  }

  onNameChange(event: any) {
    this.name = event.target.value;
    if (this.isEmpty(event.target.value)) {
      this.nameError = "Name is required"
    } else {
      this.nameError = "";
    }
  }

  onEmail(event: any) {
    this.email = event.target.value;
    if (this.isEmpty(event.target.value)) {
      this.emailError = "Email is required"
    } else {
      const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
      if (emailRegex.test(event.target.value)) {
        this.emailError = ""
      } else {
        this.emailError = "Please Enter a valid format email";
      }
    }
  }

  onPhoneNumberChange(event: any) {
    this.phoneNumber = event.target.value;
    if (this.isEmpty(event.target.value)) {
      this.phoneNumberError = "Phone number is required"
    } else {
      this.phoneNumberError = "";
    }
  }

  onPassword(event: any) {
    this.password = event.target.value;
    if (this.isEmpty(event.target.value)) {
      this.passwordError = "Password is required"
    } else {
      this.passwordError = "";
    }
  }

  onConfirmPasswordChange(event: any) {
    this.confirmPassword = event.target.value;
    if (event.target.value != this.password) {
      this.confirmPasswordError = "Confirm password does not matched"
    } else {
      this.confirmPasswordError = "";
    }
  }


  onRoleChange(event: any) {
    this.role = event.target.value;
    if (this.role.trim() == '') {
      this.roleError = "You must want to select Your User Role"
    } else {
      if (this.role == 'fieldWorker') {
        this.buttonText = "Request"
      } else {
        this.buttonText = "Sign Up"
      }
    }
  }

  onDOBChange(event:any){
    this.dob = event.target.value;
    if (this.dob.trim() == ''){
      this.dobError = "Please enter valid date"
    }else {
      this.dobError = "";
    }
  }

  onWorkTypeChange(event:any){
    this.workType = event.target.value;
    if (this.workType.trim() == ''){
      this.workTypeError = "Please select what type work you can"
    }else {
      this.workTypeError = '';
    }
  }

  signup() {
    if (this.role == 'customer') {
      if (
        this.nameError.trim() == '' &&
        this.emailError.trim() == '' &&
        this.phoneNumberError.trim() == '' &&
        this.passwordError.trim() == '' &&
        this.confirmPasswordError.trim() == '' &&
        this.roleError.trim() == ''
      ) {
        let signupData: {
          name: string,
          email: string,
          phoneNumber: string,
          password: string,
          role: string
        } = {
          name: this.name,
          email: this.email,
          phoneNumber: this.phoneNumber,
          password: this.password,
          role: this.role
        }
        console.log(signupData);
      }
    }else if (this.role == 'fieldWorker'){
      if (
        this.nameError.trim() == '' &&
        this.emailError.trim() == '' &&
        this.phoneNumberError.trim() == '' &&
        this.passwordError.trim() == '' &&
        this.confirmPasswordError.trim() == '' &&
        this.roleError.trim() == '' &&
        this.workTypeError.trim() == '' &&
        this.dobError.trim() == ''
      ) {
        let signupData: {
          name: string,
          email: string,
          phoneNumber: string,
          password: string,
          role: string,
          workType: string,
          dob:string
        } = {
          name: this.name,
          email: this.email,
          phoneNumber: this.phoneNumber,
          password: this.password,
          role: this.role,
          workType: this.workType,
          dob: this.dob
        }
        console.log(signupData);
      }
    }else {
      console.log("Please select valid user Role")
    }
  }

}
