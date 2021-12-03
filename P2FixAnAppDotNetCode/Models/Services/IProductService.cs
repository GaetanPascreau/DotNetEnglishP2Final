using System.Collections.Generic; //necessary to implement a List
namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();  //replace the return type Product[] by List<ProductT>
        Product GetProductById(int id);
        void UpdateProductQuantities(Cart cart);
    }
}
