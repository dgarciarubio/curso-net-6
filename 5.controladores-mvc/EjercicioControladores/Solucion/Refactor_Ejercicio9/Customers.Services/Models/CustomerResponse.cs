using Customers.Services.Domain;

namespace Customers.Services.Models
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public bool IsOverAge { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }

        public static CustomerResponse Mapper(Customer customer) 
        {
            return new CustomerResponse
            {
                Name = customer.Name,
                Surname = customer.Surname,
                Dni = customer.Dni,
                IsOverAge = customer.IsCustomerOverAge(),
                Email = customer.Email,
                Gender = (int)customer.Gender
            };
        }
    }
}
