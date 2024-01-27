import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotesRoutingModule } from './notes-routing.module';
import { NotesComponent } from './notes.component';
import { NoteComponent } from './components/note/note.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [NotesComponent, NoteComponent],
  imports: [CommonModule, NotesRoutingModule, ReactiveFormsModule],
})
export class NotesModule {}
