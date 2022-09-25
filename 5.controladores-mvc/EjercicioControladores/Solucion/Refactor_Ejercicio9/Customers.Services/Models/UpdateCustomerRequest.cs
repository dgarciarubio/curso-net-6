﻿namespace Customers.Services.Models
{
    public class UpdateCustomerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Dni { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
    }
}
