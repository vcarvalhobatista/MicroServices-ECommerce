using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.Web.Models.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();

        Task<ProductModel> FindProductById(long id);

        Task<ProductModel> CreateProduct(ProductModel product);

        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<bool> DeleteProductById(long id);

    }
}