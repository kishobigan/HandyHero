import { Component } from '@angular/core';

@Component({
  selector: 'app-otpverification',
  standalone: true,
  imports: [],
  templateUrl: './otpverification.component.html',
  styleUrl: './otpverification.component.css'
})
export class OTPVerificationComponent {

  moveToNext(currentInput: HTMLInputElement, nextInput: HTMLInputElement | null, prevInput: HTMLInputElement | null) {
    const maxLength = parseInt(currentInput.getAttribute('maxlength') || '0');
    const currentLength = currentInput.value.length;

    if (currentLength >= maxLength && nextInput !== null) {
      nextInput.focus();
    } else if (currentLength === 0 && prevInput !== null) {
      prevInput.focus();
    }
  }
}
