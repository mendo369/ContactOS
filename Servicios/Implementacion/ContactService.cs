using AppContactos.Models;
using AppContactos.Servicios.Contrato;

namespace AppContactos.Servicios.Implementacion
{
    public class ContactService : IContactService
    {
        public Task<bool> DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
