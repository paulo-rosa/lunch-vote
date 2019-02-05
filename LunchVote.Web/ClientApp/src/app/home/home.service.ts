import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProfessionalModel } from './models/Professional';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ElectionModel } from './models/ElectionModel';

@Injectable()
export class HomeService {
  constructor(private http: HttpClient) { }

  professionalsUrl = 'https://localhost:44325/professionals';

  electionUrl = 'https://localhost:44325/votes/elections/current';

  getProfessionals() {
    return this.http.get(this.professionalsUrl).pipe(map(response => {
      return response as Array<ProfessionalModel>;
    }));
  }

  getElection() {
    return this.http.get(this.electionUrl).pipe(map(response => {
      return response as ElectionModel;
    }));
  }

}
