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
    projectName: string;
    profilePhoto: string;
    projectWorkerName: string;
    projectStatus: any;
    statusText: string,
    projectBudget: string;
  } | undefined;

  get profilePhotoUrl(): string {
    if (this.project && this.project.profilePhoto) {
      return this.project.profilePhoto;
    } else {
      return this.noProfilePhoto;
    }
  }

  getStatusColor(): string {
    if (this.project?.projectStatus === 0) {
      this.project.statusText = "Not Started"
      return 'text-red';
    } else if (this.project?.projectStatus === 1) {
      this.project.statusText = "Completed"
      return 'text-green';
    }else if (this.project?.projectStatus === -1) {
      this.project.statusText = "Ongoing"
      return 'text-orange';
    }
    else {
      return '';
    }
  }


}
