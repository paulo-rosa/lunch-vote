import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HomeService } from './home.service';
import { ProfessionalModel } from './models/Professional';
import { debug } from 'util';
import { RouterLink, Router } from '@angular/router';
import { ElectionModel } from './models/ElectionModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  professionalForm: FormGroup;

  professionalList: Array<ProfessionalModel>;

  currElection: ElectionModel;

  selectedProfId: string;

  constructor(private fb: FormBuilder, private homeService: HomeService, private router: Router) { }

  ngOnInit() {

    this.homeService.getElection()
      .subscribe(res => {
        this.currElection = res;
        console.log(this.currElection);
      });

    this.homeService.getProfessionals()
      .subscribe(res => {
        this.professionalList = res;
      });

    this.professionalForm = this.fb.group({
      professionalControl: ''
    });
  }

  changeSelectedProfessional(id: string) {
    this.selectedProfId = id;
  }

  onSubmit(id: string) {
    if (!id) {
      alert('Select a professional!');
    }
    else {
      this.router.navigate(['/vote', id]);
    }
  }

}
