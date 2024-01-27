import { Component } from '@angular/core';
import { ContactsService } from './contacts.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.css',
})
export class ContactsComponent {
  contacts: any[] = [];
  addContact = false;
  formContact: FormGroup;

  constructor(private contactsService: ContactsService) {
    this.formContact = new FormGroup({
      name: new FormControl('', Validators.required),
      lastname: new FormControl('', Validators.required),
      phone: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.getContacts();
  }

  displayAddContact() {
    this.addContact = !this.addContact;
  }

  getContacts() {
    this.contactsService
      .getContacts()
      .subscribe((contacts) => (this.contacts = contacts.value));
  }

  onSaveContact() {
    this.contactsService
      .create(this.formContact.value)
      .subscribe((res) =>
        res.status ? (this.addContact = false) : (this.addContact = true)
      );
  }
}
