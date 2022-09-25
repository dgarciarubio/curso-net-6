namespace Customers.Api.Models
{
    public class GetCustomersByPageResponse
    {
        public int CustomersCount { get; set; }
        public IEnumerable<CustomerResponse> Data { get; set; }
    }
}
