import { Component } from '@angular/core';
import { NotesService } from './notes.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrl: './notes.component.css',
})
export class NotesComponent {
  notes: any[] = [];
  addNote = false;
  formNote: FormGroup;

  constructor(private notesService: NotesService) {
    this.formNote = new FormGroup({
      title: new FormControl('', [Validators.required]),
      contentNote: new FormControl('', [Validators.required]),
    });
  }

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

  async onSaveNote() {
    this.notesService
      .create(this.formNote.value)
      .subscribe((res) =>
        res.status ? (this.addNote = false) : (this.addNote = true)
      );
  }
}
