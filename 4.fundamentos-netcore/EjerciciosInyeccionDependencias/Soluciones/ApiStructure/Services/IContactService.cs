using ApiStructure.Models;

namespace ApiStructure.Services
{
    public interface IContactService
    {
        Contact? GetContact(int contactId);
        IEnumerable<Contact> GetContacts();
        int CreateContact(string name, string telephoneNumber);
        void UpdateContact(int id, string name, string telephoneNumber);
        void DeleteContact(int id);
    }
}
