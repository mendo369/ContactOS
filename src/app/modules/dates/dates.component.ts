import { Component } from '@angular/core';
import { DatesService } from './dates.service';

@Component({
  selector: 'app-dates',
  templateUrl: './dates.component.html',
  styleUrl: './dates.component.css',
})
export class DatesComponent {
  dates: any[] = [];

  constructor(private datesService: DatesService) {}

  ngOnInit(): void {
    this.getDates();
  }

  getDates() {
    this.datesService
      .getDates()
      .subscribe((dates) => (this.dates = dates.value));
  }
}
