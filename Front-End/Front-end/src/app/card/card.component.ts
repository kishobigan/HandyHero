import {Component, Input} from '@angular/core';
import {NgClass} from "@angular/common";
@Component({
  selector: 'app-card',
  standalone: true,
  imports: [
    NgClass
  ],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {

  noProfilePhoto = "https://res.cloudinary.com/dpmqdx02n/image/upload/v1711616632/noProfile_jwjkro.jpg";

  @Input() project: {
    name: string;
    profilePhoto: string;
    workerName: string;
    status: string;
    budget: string;
  } | undefined;

  get profilePhotoUrl(): string {
    if (this.project && this.project.profilePhoto) {
      return this.project.profilePhoto;
    } else {
      // console.log("no photo")
      return this.noProfilePhoto;
    }
  }

  getStatusColor(): string {
    if (this.project?.status === 'On Going') {
      return 'text-orange';
    } else if (this.project?.status === 'Completed') {
      return 'text-green';
    } else {
      return '';
    }
  }


}
