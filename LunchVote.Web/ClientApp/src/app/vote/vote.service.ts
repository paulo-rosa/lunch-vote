import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RestaurantModel } from './models/RestaurantModel';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

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

  postVote(data) {
    return this.http.post(this.postVoteUrl, data);
  }

}
