import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { RestaurantModel } from './models/RestaurantModel';
import { VoteService } from './vote.service';
import { Router, RouterLink, ActivatedRoute } from '@angular/router';
import { switchMap, map } from 'rxjs/operators';
import { debug } from 'util';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css']
})
export class VoteComponent implements OnInit {

  voteForm: FormGroup;

  restaurantList: Array<RestaurantModel>;

  selectedProfessionalId: string;

  selectedRestaurantId: string;

  constructor(private fb: FormBuilder, private voteService: VoteService, private actRouter: ActivatedRoute) { }

  ngOnInit() {

    this.selectedProfessionalId = this.actRouter.snapshot.paramMap.get('professionalId');

    this.voteService.getRestaurants()
      .subscribe(res => {
        this.restaurantList = res;
      });

    this.voteForm = this.fb.group({
      restaurantControl: ""
    });
  }


  onSubmit(id: string) {
    debugger;
    if (!id) {
      alert("Select a professional!");
    }
    else {
      debugger;
      this.voteService.postVote({
        "professionalId": this.selectedProfessionalId,
        "restaurantId": this.selectedRestaurantId
      });
    }
  }
}
