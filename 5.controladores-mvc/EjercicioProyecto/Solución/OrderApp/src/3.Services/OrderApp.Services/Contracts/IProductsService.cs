using OrderApp.Models.Products;

namespace OrderApp.Services.Contracts
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductResponse>> GetAlls();
        Task<ProductResponse> Get(int id);
        Task<int> Create(CreateProductRequest customer);
        Task Update(int id, UpdateProductRequest client);
        Task Delete(int id);
    }
}
