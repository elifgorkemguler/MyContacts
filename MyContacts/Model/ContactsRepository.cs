using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyContacts.Model
{
    public class ContactsRepository
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo { Id = 1, NameSurname = "Hüseyin Şimşek", Email = "huseyinsimsek@gmail.com", PhoneNumber = "053357252" }
        };

        private static int maxId = 2;

        public ContactsRepository()
        {
        }

        public ObservableCollection<ContactInfo> GetContacts()
        {
            return new ObservableCollection<ContactInfo>(contacts);
        }

        public void AddContact(ContactInfo contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            contact.Id = maxId++;
            contacts.Add(contact);
        }

        public ContactInfo GetContact(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateContact(ContactInfo contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            var existingContact = contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.NameSurname = contact.NameSurname;
                existingContact.Email = contact.Email;
                existingContact.PhoneNumber = contact.PhoneNumber;
            }
        }
    }

   }
