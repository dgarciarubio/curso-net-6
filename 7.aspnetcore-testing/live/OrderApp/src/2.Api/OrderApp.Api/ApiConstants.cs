namespace OrderApp.Api
{
    public class ApiConstants
    {
        public const string BaseUri = "api";
        public const string CustomerIdParam = "{customerId:int:min(0)}";
        public const string CustomersUri = "customers";

        public const string ProductsUri = "products";
        public const string ProductIdParam = "{productId:int:min(0)}";
    }
}
