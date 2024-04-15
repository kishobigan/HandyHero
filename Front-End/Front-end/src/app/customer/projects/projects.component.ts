import {Component, OnInit} from '@angular/core';
import {CardComponent} from "../../card/card.component";
import {NgForOf} from "@angular/common";
import {ProjectsService} from "../../../Services/Customer/projects.service";

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
export class ProjectsComponent implements OnInit{

  projects: any[] = [];

  constructor(private projectService: ProjectsService) {
  }

  ngOnInit() {
    let userId = localStorage.getItem('Id');
    this.projectService.getMyProjects(userId).subscribe(
      (data) => {
        console.log(data)
        this.projects = data;
      },
      (error) => {
        console.log("error while getting projects : ", error);
      }
    )
  }
}
