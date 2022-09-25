using OrderApp.Domain;
using OrderApp.Models;
using OrderApp.Models.Customers;

namespace OrderApp.Services.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetAlls();
        Task<CustomerResponse> Get(int id);
        Task<int> Create(CreateCustomerRequest customer);
        Task Update(int id, UpdateCustomerRequest client);
        Task Delete(int id);
    }
}
