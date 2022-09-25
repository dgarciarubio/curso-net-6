using Customers.Services.Domain;
using Customers.Services.Models;
using Microsoft.Extensions.Options;

namespace Customers.Services.Services
{
    public class CustomerService : ICustomersService
    {
        private readonly List<Customer> _customers;
        private readonly int _pageSize;

        public CustomerService(IOptions<Settings> settings) 
        {
            _customers = new List<Customer>();
            _pageSize = settings?.Value?.PageSize ?? 10;
        }

        public int CreateCustomer(CreateCustomerRequest customerRequest)
        {
            var customer = new Customer(
                customerRequest.Id, 
                customerRequest.Name, 
                customerRequest.Surname, 
                customerRequest.Dni, 
                customerRequest.Age, 
                customerRequest.Email, 
                (Gender)customerRequest.Gender);

            _customers.Add(customer);
            return customer.Id;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(customer => customer.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
            else
            {
                throw new Exception("Student Not Found");
            }
        }

        public IEnumerable<CustomerResponse> GetCustomers()
        {
            return _customers.Select(customer => CustomerResponse.Mapper(customer));
        }

        public IEnumerable<CustomerResponse> GetCustomersByPage(int page)
        {
            return _customers.Skip(_pageSize * page)
                             .Take(_pageSize)
                             .Select(customer => CustomerResponse.Mapper(customer));
        }

        public CustomerResponse? GetCustomer(int customerId)
        {
            var customer = _customers.FirstOrDefault(customer => customer.Id == customerId);
            return customer != null ? CustomerResponse.Mapper(customer) : null;
        }

        public void UpdateCustomer(int id, UpdateCustomerRequest customerRequest)
        {
            var customer = _customers.FirstOrDefault(customer => customer.Id == id);
            if (customer != null)
            {
                customer.Update(
                    customerRequest.Name, 
                    customerRequest.Surname, 
                    customerRequest.Dni, 
                    customerRequest.Age, 
                    customerRequest.Email, 
                    (Gender)customerRequest.Gender);
            }
            else
            {
                throw new Exception("Student Not Found");
            }
        }
    }
}
