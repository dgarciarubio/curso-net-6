namespace ContactsProject.Services
{
    public interface IContactLogService
    {
        void AddContactLog(int customerId);
        int GetContactAccessLog(int customerId);
    }
}
