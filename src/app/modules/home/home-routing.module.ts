import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home.component';
import { ContactsComponent } from '../contacts';
import { NotesComponent } from '../notes';
import { DatesComponent } from '../dates';
import { NoteComponent } from '../notes/components/note/note.component';
import { ContactComponent } from '../contacts/components/contact/contact.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'contacts' },
      {
        path: 'contacts',
        children: [
          { path: '', component: ContactsComponent },
          { path: 'edit/:id', component: ContactComponent },
        ],
      },
      {
        path: 'notes',
        children: [
          { path: '', component: NotesComponent },
          {
            path: 'edit/:id',
            component: NoteComponent,
          },
        ],
      },
      { path: 'dates', component: DatesComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
