import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RestaurantModel } from './models/RestaurantModel';
import { VoteResultModel } from './models/VoteResultModel';
import { VoteService } from './vote.service';
import { VotePostModel } from './models/VotePostModel';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css']
})
export class VoteComponent implements OnInit {

  voteForm: FormGroup;
  restaurantList: Array<RestaurantModel>;
  voteResult: VoteResultModel;
  selectedProfessionalId: string;
  selectedRestaurantId: string;

  constructor(private fb: FormBuilder, private voteService: VoteService, private actRouter: ActivatedRoute, private router: Router) { }

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
    if (!id) {
      alert("Select a professional!");
    }
    else {
      const votePostModel = new VotePostModel();
      votePostModel.professionalId = this.selectedProfessionalId;
      votePostModel.restaurantId = this.selectedRestaurantId;

      this.voteService.postVote(votePostModel)
        .subscribe(
          res => {
            alert('Voto Registrado com Sucesso!');
            this.router.navigate(['/']);
          },
          err => {
            alert(err.error);
            this.router.navigate(['/']);
          }
        );
    }
  }
}
