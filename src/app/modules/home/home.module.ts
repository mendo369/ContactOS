import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { NavbarComponent } from '../../components/navbar/navbar.component';

@NgModule({
  declarations: [HomeComponent, NavbarComponent],
  imports: [CommonModule, HomeRoutingModule],
})
export class HomeModule {}
