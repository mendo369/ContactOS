import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DatesRoutingModule } from './dates-routing.module';
import { DatesComponent } from './dates.component';

@NgModule({
  declarations: [DatesComponent],
  imports: [CommonModule, DatesRoutingModule],
})
export class DatesModule {}
