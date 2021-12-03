using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;
using System.Linq; //necessary to use ToList()

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts().ToList(); //convert the Product Array into a List of Product
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // Instanciate a new ProductService and use it to recover all products from the repository into a new list
            ProductService productService = new ProductService(_productRepository, _orderRepository);
            List<Product> repositoryList = productService.GetAllProducts();
            //search within that list for a product with the provided id and return it
            Product product = repositoryList.FirstOrDefault(prod => prod.Id == id);
            return product;
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
        }
    }
}
