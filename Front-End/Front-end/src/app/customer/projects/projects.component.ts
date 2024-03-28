import { Component } from '@angular/core';
import {CardComponent} from "../../card/card.component";
import {NgForOf} from "@angular/common";

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [
    CardComponent,
    NgForOf
  ],
  templateUrl: './projects.component.html',
  styleUrl: './projects.component.css'
})
export class ProjectsComponent {

  projects:{name:string, profilePhoto:string, workerName:string, status:string, budget:string}[] = [
    {
      name: 'painting',
      profilePhoto: '',
      workerName: 'Sugeevan',
      status: 'On Going',
      budget: '10000'
    },
    {
      name: 'painting',
      profilePhoto: '',
      workerName: 'Sugeevan',
      status: 'Completed',
      budget: '10000'
    },
    {
      name: 'painting',
      profilePhoto: '',
      workerName: 'Sugeevan',
      status: 'On Going',
      budget: '10000'
    },
    {
      name: 'painting',
      profilePhoto: '',
      workerName: 'Sugeevan',
      status: 'Completed',
      budget: '10000'
    },
    {
      name: 'painting',
      profilePhoto: '',
      workerName: 'Sugeevan',
      status: 'On Going',
      budget: '10000'
    }
  ]
}
