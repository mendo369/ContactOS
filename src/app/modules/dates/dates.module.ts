import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DatesRoutingModule } from './dates-routing.module';
import { DatesComponent } from './dates.component';
import { DateComponent } from './components/date/date.component';

@NgModule({
  declarations: [DatesComponent, DateComponent],
  imports: [CommonModule, DatesRoutingModule],
})
export class DatesModule {}
