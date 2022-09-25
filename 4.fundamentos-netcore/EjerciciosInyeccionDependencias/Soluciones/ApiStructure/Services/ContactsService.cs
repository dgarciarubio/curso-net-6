using ApiStructure.Models;

namespace ApiStructure.Services
{
    public class ContactsService : IContactService
    {
        private readonly List<Contact> _contacts;

        public ContactsService()
        {
            this._contacts = new List<Contact>();
        }

        public Contact? GetContact(int studentId)
        {
            return _contacts.FirstOrDefault(student => student.Id == studentId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public int CreateContact(string name, string telephoneNumber)
        {
            var id = _contacts.Count > 0 ? _contacts.Max(contact => contact.Id) : 1;
            var newContact = new Contact { Id = id, Name = name, TelephoneNumber = telephoneNumber };
            _contacts.Add(newContact);
            return newContact.Id;
        }

        public void UpdateContact(int id, string name, string telephoneNumber)
        {
            var student = _contacts.FirstOrDefault(student => student.Id == id);
            if (student != null)
            {
                student.Name = name;
                student.TelephoneNumber = telephoneNumber;
            }
            else
            {
                throw new Exception("Contact Not Found");
            }
        }

        public void DeleteContact(int id)
        {
            var _contact = _contacts.FirstOrDefault(_contact => _contact.Id == id);
            if (_contact != null)
            {
                _contacts.Remove(_contact);
            }
            else
            {
                throw new Exception("Student Not Found");
            }
        }
    }
}
