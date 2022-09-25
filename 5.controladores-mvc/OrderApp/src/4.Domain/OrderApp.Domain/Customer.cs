using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Domain
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public DateTime LastUpdate { get; private set; }

        public Customer(int id, string name, string surname, int age, string email)
        {
            this.Id = id;
            this.Update(name, surname, age, email);
        }

        public void Update(string name, string surname, int age, string email)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            LastUpdate = DateTime.Now;
        }


    }
}
