namespace Customers.Services.Models
{
    public class GetCustomersByPageResponse
    {
        public int CustomersCount { get; set; }
        public IEnumerable<CustomerResponse> Data { get; set; }
    }
}
