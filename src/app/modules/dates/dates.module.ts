import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DatesRoutingModule } from './dates-routing.module';
import { DatesComponent } from './dates.component';
import { DateComponent } from './components/date/date.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [DatesComponent, DateComponent],
  imports: [CommonModule, DatesRoutingModule, ReactiveFormsModule],
})
export class DatesModule {}
