import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home.component';
import { ContactsComponent } from '../contacts';
import { NotesComponent } from '../notes';
import { DatesComponent } from '../dates';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'contacts' },
      { path: 'contacts', component: ContactsComponent },
      { path: 'notes', component: NotesComponent },
      { path: 'dates', component: DatesComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
