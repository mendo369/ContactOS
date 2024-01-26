import { Component } from '@angular/core';
import { ContactsService } from './contacts.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.css',
})
export class ContactsComponent {
  contacts: any[] = [];

  constructor(private contactsService: ContactsService) {}

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts() {
    this.contactsService
      .getContacts()
      .subscribe((contacts) => (this.contacts = contacts.value));
  }
}
