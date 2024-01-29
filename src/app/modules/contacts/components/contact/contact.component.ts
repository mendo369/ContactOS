import { Component } from '@angular/core';
import { ContactsService } from '../../contacts.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.css',
})
export class ContactComponent {
  contactId: number;
  formContact: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactsService,
    private router: Router
  ) {
    this.contactId = 0;

    this.formContact = new FormGroup({
      name: new FormControl('', [Validators.minLength(1), Validators.required]),
      lastname: new FormControl(''),
      phone: new FormControl('', [Validators.minLength(1)]),
      email: new FormControl(''),
      address: new FormControl(''),
    });
  }

  ngOnInit(): void {
    try {
      this.contactId = parseInt(this.route.snapshot.paramMap.get('id')!);
      this.getContact(this.contactId);
    } catch (error) {
      this.contactId = 0;
    }
  }

  getContact(id: number) {
    this.contactService.getContact(id).subscribe((res) => {
      if (res.status) {
        this.formContact.patchValue({
          name: res.value.name,
          lastname: res.value.lastname,
          phone: res.value.phone,
          email: res.value.email,
          address: res.value.address,
        });
        return;
      }
      alert('error');
    });
  }

  onSaveContact() {
    this.contactService
      .update(this.formContact.value, this.contactId)
      .subscribe((res) => {
        if (res.status) {
          alert('Contacto actualizado');
          this.router.navigate(['/contacts']);
          return;
        }
        alert('error');
      });
  }

  onDeleteContact() {
    this.contactService.delete(this.contactId).subscribe((res) => {
      if (res.status) {
        alert('Contacto eliminado');
        this.router.navigate(['/contacts']);
        return;
      }
      alert('error');
    });
  }

  onCancel() {
    this.router.navigate(['/contacts']);
  }
}
