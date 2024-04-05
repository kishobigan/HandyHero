import {Component, EventEmitter, Input, Output} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {NgForOf} from "@angular/common";
import {StarRatingComponent} from "../../star-rating/star-rating.component";

@Component({
  selector: 'app-find',
  standalone: true,
  imports: [
    FormsModule,
    NgForOf,
    StarRatingComponent
  ],
  templateUrl: './find.component.html',
  styleUrl: './find.component.css'
})
export class FindComponent {
  noProfilePhoto = "https://res.cloudinary.com/dpmqdx02n/image/upload/v1711616632/noProfile_jwjkro.jpg";


  districts: { name: string, number: number }[] = [
    {name: 'Colombo', number: 1},
    {name: 'Gampaha', number: 2},
    {name: 'Kalutara', number: 3},
    {name: 'Kandy', number: 4},
    {name: 'Matale', number: 5},
    {name: 'Nuwara Eliya', number: 6},
    {name: 'Galle', number: 7},
    {name: 'Matara', number: 8},
    {name: 'Hambantota', number: 9},
    {name: 'Jaffna', number: 10},
    {name: 'Kilinochchi', number: 11},
    {name: 'Mannar', number: 12},
    {name: 'Vavuniya', number: 13},
    {name: 'Mullaitivu', number: 14},
    {name: 'Batticaloa', number: 15},
    {name: 'Ampara', number: 16},
    {name: 'Trincomalee', number: 17},
    {name: 'Kurunegala', number: 18},
    {name: 'Puttalam', number: 19},
    {name: 'Anuradhapura', number: 20},
    {name: 'Polonnaruwa', number: 21},
    {name: 'Badulla', number: 22},
    {name: 'Monaragala', number: 23},
    {name: 'Ratnapura', number: 24},
    {name: 'Kegalle', number: 25}
  ];
  rating: string[] = ['5-star', '4-star', '3-star', '2-star', '1-star'];


  selectedDistrict: string = '';
  selectedRating: string = '';

  district = '';
  rate = ''

  constructor() {

  }

  onDistrictSortChange(event: any) {
    this.district = event.target.value;
    console.log(this.district)
  }

  onRatingChange(event: any) {
    this.selectedRating = event.target.value;
    console.log(this.selectedRating);
  }

  ratingNumber: number = 3;

  employees: {name:string,profilePhoto:string, workerType:string, district:string, ratingValue:string}[] = [
    {name:'Sugeevan',profilePhoto:'',workerType: 'Painter', district:'mullaithivu',ratingValue:'3-star'},
    {name:'Sugeevan',profilePhoto:'',workerType: 'Plumber', district:'jaffna',ratingValue:'4-star'},
    {name:'Sugeevan',profilePhoto:'',workerType: 'Mesan', district:'vavuniya',ratingValue:'3-star'},
    {name:'Sugeevan',profilePhoto:'',workerType: 'Carpenter', district:'manar',ratingValue:'2-star'},
    {name:'Sugeevan',profilePhoto:'',workerType: 'Electrician', district:'kilinochchi',ratingValue:'5-star'},
  ];

  convertRatingToInt(ratingValue: string): number {
    switch (ratingValue) {
      case '5-star':
        return 5;
      case '4-star':
        return 4;
      case '3-star':
        return 3;
      case '2-star':
        return 2;
      case '1-star':
        return 1;
      default:
        return 0;
    }
  }


}
