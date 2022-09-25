namespace OrderApp.Domain
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime LastUpdate { get; private set; }

        public Product(int id, string name, string description, decimal price) 
        {
            this.Id = id;
            this.Update(name, description, price);
        }

        public void Update(string name, string description, decimal price) 
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.LastUpdate = DateTime.UtcNow;
        }
    }
}
