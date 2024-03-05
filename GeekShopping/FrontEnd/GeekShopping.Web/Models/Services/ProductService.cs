using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.Web.Models.Services.IServices;
using GeekShopping.Web.Models.Utils;

namespace GeekShopping.Web.Models.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";        

        public ProductService(HttpClient client)
        {
            _client = client;
            
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {            
            var response = await _client.PostAsJson(BasePath,product);
            if(response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();
            else throw new Exception("Something wemt wrong when calling API");
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.PostAsJson(BasePath,id);
            if(response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception("Something wemt wrong when calling API");
        }
        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();            
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();    
        }

    }
}