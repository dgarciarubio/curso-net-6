namespace Customers.Services.Domain
{
    public class Customer
    {
        private const int OverAgeLimit = 18;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Dni { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime LastUpdate { get; private set; }

        public Customer(int id, string name, string surname, string dni, int age, string email, Gender gender)
        {
            this.Id = id;
            this.Update(name, surname, dni, age, email, gender);
        }

        public void Update(string name, string surname, string dni, int age, string email, Gender gender)
        {
            this.Name = name;
            this.Surname = surname;
            this.Dni = dni;
            this.Age = age;
            this.Email = email;
            this.Gender = gender;
            this.LastUpdate = DateTime.UtcNow;
        }

        public bool IsCustomerOverAge()
        {
            return Age >= OverAgeLimit;
        } 
    }
}