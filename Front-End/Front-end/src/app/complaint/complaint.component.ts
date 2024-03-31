import { Component } from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-complaint',
  standalone: true,
  imports: [
    NgIf,
    NgForOf
  ],
  templateUrl: './complaint.component.html',
  styleUrl: './complaint.component.css'
})
export class ComplaintComponent {

  role: any = '';
  email = '';
  name = '';
  complaint = '';

  emailError = '';
  complaintError = '';

  complaints: {email:string,name:string,complaint:string}[] = [
    {email:'k@k.com',name:'kisho',complaint:'sgbsb'},
    {email:'k@k.com',name:'',complaint:'sgbsb'},
  ]

  constructor() {
    this.role = localStorage.getItem('role');
  }

  onEmailChange(event:any){
    this.email = event.target.value;

    const emailRegex: RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (emailRegex.test(this.email)){
      this.emailError = "";
    }else if (this.email === ''){
      this.emailError = "You must want to provide email"
    }
    else {
      this.emailError = "Please enter a valid email"
    }
  }

  onNameChange(event:any){
    this.name = event.target.value;
  }

  onComplaintChange(event:any){
    this.complaint = event.target.value;

    if (this.complaint === ''){
      this.complaintError = "You muster enter any complaint"
    }else {
      this.complaintError = '';
    }
  }

  onComplaint(){
    if (this.complaintError === '' && this.emailError === ''){
      let complaintData: { email: string, name: string, complaint: string }[] = [
        {
          email: this.email,
          name: this.name,
          complaint: this.complaint
        }
      ];
      console.log(complaintData)
    }else {
      console.log("please fill all field")
    }
  }

}
