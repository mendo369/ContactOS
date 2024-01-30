import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DatesService } from '../../dates.service';

@Component({
  selector: 'app-date',
  templateUrl: './date.component.html',
  styleUrl: './date.component.css',
})
export class DateComponent {
  dateId: number;
  formDate: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private datesService: DatesService
  ) {
    this.dateId = 0;
    this.formDate = this.fb.group({
      title: ['', Validators.required],
      date: [null, Validators.required],
      description: [''],
    });
  }

  ngOnInit(): void {
    try {
      this.dateId = parseInt(this.route.snapshot.paramMap.get('id')!);
      this.getDate(this.dateId);
    } catch (error) {
      this.dateId = 0;
    }
  }

  getDate(id: number) {
    this.datesService.getDate(id).subscribe((res) => {
      if (res.status) {
        const dateValue = new Date(res.value.date).toISOString().split('T')[0];
        this.formDate.patchValue({
          title: res.value.title,
          date: dateValue, // Corregido aquí
          description: res.value.description,
        });
        console.warn(dateValue);
        return;
      }
      alert('error');
    });
  }

  onSaveDate() {
    this.datesService
      .update(this.formDate.value, this.dateId)
      .subscribe((res) => {
        if (res.status) {
          alert('Fecha actualizada');
          this.router.navigate(['/dates']);
          return;
        }
        alert('error');
      });
  }

  onDeleteDate() {
    this.datesService.delete(this.dateId).subscribe((res) => {
      if (res.status) {
        alert('Fecha eliminada');
        this.router.navigate(['/dates']);
        return;
      }
      alert('error');
    });
  }

  onCancel() {
    this.router.navigate(['/dates']);
  }
}
