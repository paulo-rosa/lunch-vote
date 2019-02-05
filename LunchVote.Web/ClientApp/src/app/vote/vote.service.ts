import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { RestaurantModel } from './models/RestaurantModel';
import { VoteResultModel } from './models/VoteResultModel';
import { VotePostModel } from './models/VotePostModel';

@Injectable()
export class VoteService {
  constructor(private http: HttpClient) { }

  restaurantsUrl = 'https://localhost:44325/restaurants';
  postVoteUrl = 'https://localhost:44325/votes';

  getRestaurants() {
    return this.http.get(this.restaurantsUrl).pipe(map(response => {
      return response as Array<RestaurantModel>;
    }));
  }

  postVote(data: VotePostModel) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.post(this.postVoteUrl, data, httpOptions).pipe(map(response => {
      return response as VoteResultModel;
    }));
  }

}
