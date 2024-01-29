import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NotesService } from '../../notes.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrl: './note.component.css',
})
export class NoteComponent {
  noteId: number;
  formNote: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private noteService: NotesService,
    private router: Router
  ) {
    this.noteId = 0;

    this.formNote = new FormGroup({
      title: new FormControl('', [
        Validators.required,
        Validators.minLength(1),
      ]),
      contentNote: new FormControl('', [
        Validators.required,
        Validators.minLength(1),
      ]),
    });
  }

  ngOnInit(): void {
    try {
      this.noteId = parseInt(this.route.snapshot.paramMap.get('id')!);
      this.getNote(this.noteId);
    } catch (error) {
      this.noteId = 0;
    }
  }

  getNote(id: number) {
    this.noteService.getNote(id).subscribe((res) => {
      if (res.status) {
        this.formNote.patchValue({
          title: res.value.title,
          contentNote: res.value.contentNote,
        });
        return;
      }
      alert('error');
    });
  }

  onSaveNote() {
    this.noteService
      .update(this.formNote.value, this.noteId)
      .subscribe((res) => {
        if (res.status) {
          alert('Nota actualizada');
          this.router.navigate(['/notes']);
          return;
        }
        alert('error');
      });
  }

  onDeleteNote() {
    this.noteService.delete(this.noteId).subscribe((res) => {
      if (res.status) {
        alert('Nota eliminada');
        this.router.navigate(['/notes']);
        return;
      }
      alert('error');
    });
  }

  onCancel() {
    this.router.navigate(['/notes']);
  }
}
