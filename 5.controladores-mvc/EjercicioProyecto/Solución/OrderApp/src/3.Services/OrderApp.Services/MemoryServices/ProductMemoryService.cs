using OrderApp.Domain;
using OrderApp.Domain.Exceptions;
using OrderApp.Models.Products;
using OrderApp.Services.Contracts;

namespace OrderApp.Services.MemoryServices
{
    public class ProductMemoryService : IProductsService
    {
        private readonly List<Product> _products = new List<Product>();

        public async Task<int> Create(CreateProductRequest productRequest)
        {
            var newId = 1;
            if (_products.Count() > 0)
            {
                newId = _products.Max(clientEntity => clientEntity.Id) + 1;
            }

            var product = new Product(newId, productRequest.Name, productRequest.Description, productRequest.Price);
            _products.Add(product);
            return product.Id;
        }

        public async Task Delete(int id)
        {
            var product = _products.FirstOrDefault(c => c.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            else
            {
                throw new NotFoundException("Product");
            }
        }

        public async Task<ProductResponse?> Get(int id)
        {
            var product = _products.FirstOrDefault(client => client.Id == id);
            return product != null ? ProductResponse.ToMapper(product) : null;
        }

        public async Task<IEnumerable<ProductResponse>> GetAlls()
        {
            return _products.Select(product => ProductResponse.ToMapper(product));
        }

        public async Task Update(int id, UpdateProductRequest productRequest)
        {
            var product = _products.FirstOrDefault(c => c.Id == id);
            if (product != null)
            {
                product.Update(productRequest.Name, productRequest.Description, productRequest.Price);
            }
            else
            {
                throw new NotFoundException("Product");
            }
        }
    }
}
