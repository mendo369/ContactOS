import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { NavbarComponent } from '../../components/navbar/navbar.component';
import { NavigationComponent } from '../../components/navigation/navigation.component';

@NgModule({
  declarations: [HomeComponent, NavbarComponent, NavigationComponent],
  imports: [CommonModule, HomeRoutingModule],
})
export class HomeModule {}
