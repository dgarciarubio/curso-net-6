using OrderApp.Domain;
using OrderApp.Domain.Exceptions;
using OrderApp.Models;
using OrderApp.Services.Contracts;

namespace OrderApp.Services.MemoryServices
{
    public class CustomerMemoryService : ICustomerService
    {
        private readonly List<Customer> _customers = new List<Customer>();

        public async Task<int> Create(CreateCustomerRequest customerRequest)
        {
            var newId = 1;
            if (_customers.Count() > 0)
            {
                newId = _customers.Max(clientEntity => clientEntity.Id) + 1;
            }

            var customer = new Customer(newId, customerRequest.Name, customerRequest.Surname, customerRequest.Age, customerRequest.Email);
            _customers.Add(customer);
            return customer.Id;
        }

        public async Task<CustomerResponse?> Get(int id)
        {
            var customer = _customers.FirstOrDefault(client => client.Id == id);
            return customer != null ? CustomerResponse.ToMapper(customer) : null;
        }

        public async Task<IEnumerable<CustomerResponse>> GetAlls()
        {
            return _customers.Select(customer => CustomerResponse.ToMapper(customer));
        }

        public async Task Update(int id, UpdateCustomerRequest customerDto)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customer.Update(customerDto.Name, customerDto.Surname, customerDto.Age, customerDto.Email);
            }
            else
            {
                throw new NotFoundException("No se ha encontrado el cliente");
            }
        }

        public async Task Delete(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
            else
            {
                throw new NotFoundException("No se ha encontrado el cliente");
            }
        }
    }
}
