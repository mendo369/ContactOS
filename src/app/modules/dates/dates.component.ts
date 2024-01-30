import { Component } from '@angular/core';
import { DatesService } from './dates.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-dates',
  templateUrl: './dates.component.html',
  styleUrl: './dates.component.css',
})
export class DatesComponent {
  dates: any[] = [];
  addDate = false;
  formDate: FormGroup;

  // constructor(private datesService: DatesService) {
  //   this.formDate = new FormGroup({
  //     title: new FormControl(''),
  //     date: new FormControl(''),
  //     description: new FormControl(''),
  //   });
  // }

  constructor(private datesService: DatesService, private fb: FormBuilder) {
    this.formDate = this.fb.group({
      title: ['', Validators.required],
      date: [null, Validators.required],
      description: [''],
    });
  }

  ngOnInit(): void {
    this.getDates();
  }

  getDates() {
    this.datesService
      .getDates()
      .subscribe((dates) => (this.dates = dates.value));
  }

  displayAddDate() {
    this.addDate = !this.addDate;
  }

  onSaveDate() {
    this.datesService
      .create(this.formDate.value)
      .subscribe((res) =>
        res.status ? (this.addDate = false) : (this.addDate = true)
      );
  }
}
