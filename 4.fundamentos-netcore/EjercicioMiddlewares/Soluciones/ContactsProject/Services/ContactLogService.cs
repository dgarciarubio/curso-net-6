namespace ContactsProject.Services
{
    public class ContactLogService : IContactLogService
    {
        private readonly Dictionary<int, int> _customersLogDictionary;

        public ContactLogService()
        {
            _customersLogDictionary = new Dictionary<int, int>();
        }

        public void AddContactLog(int customerId)
        {
            if (_customersLogDictionary.ContainsKey(customerId))
            {
                _customersLogDictionary[customerId] = _customersLogDictionary[customerId] + 1;
            }
            else
            {
                _customersLogDictionary.Add(customerId, 1);
            }
        }

        public int GetContactAccessLog(int customerId)
        {
            if (_customersLogDictionary.ContainsKey(customerId))
            {
                return _customersLogDictionary[customerId];
            }
            else
            {
                return 0;
            }
        }
    }
}
