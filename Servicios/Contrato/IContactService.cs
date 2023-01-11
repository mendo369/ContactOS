using AppContactos.Models;

namespace AppContactos.Servicios.Contrato
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactDetails(int id);
        Task<bool> InsertContact(Contact contact);
        Task<bool> UpdateContact(Contact contact);
        Task<bool> DeleteContact(int id);
        Task<bool> SaveContact(Contact contact);
    }
}
