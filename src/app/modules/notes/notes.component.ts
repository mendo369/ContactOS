import { Component } from '@angular/core';
import { NotesService } from './notes.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrl: './notes.component.css',
})
export class NotesComponent {
  notes: any[] = [];
  addNote = false;

  constructor(private notesService: NotesService) {}

  ngOnInit(): void {
    this.getNotes();
  }

  displayAddNote() {
    this.addNote = !this.addNote;
  }

  getNotes() {
    this.notesService
      .getNotes()
      .subscribe((notes) => (this.notes = notes.value));
  }
}
