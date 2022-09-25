using Customers.Services.Domain;
using Customers.Services.Models;

namespace Customers.Services.Services
{
    public interface ICustomersService
    {
        CustomerResponse? GetCustomer(int customerId);
        IEnumerable<CustomerResponse> GetCustomersByPage(int page);
        IEnumerable<CustomerResponse> GetCustomers();
        int CreateCustomer(CreateCustomerRequest customerRequest);
        void UpdateCustomer(int id, UpdateCustomerRequest customerRequest);
        void DeleteCustomer(int id);
    }
}
