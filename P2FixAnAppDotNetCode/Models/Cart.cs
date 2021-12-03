using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        //Create a readonly list that will contain the actual cartLine list to be transmitted to the enum
        private readonly List<CartLine> _cartLines = new List<CartLine>();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        /// 
      //This method was modified to prevent it from reinitializing the list each time it is called. Now it returns the current list

        private List<CartLine> GetCartLineList()
        {
            return _cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            //Create a CartLine object that will contain the result of a search within the current CartLine list
            //for a Product Id matching the Id from the product parameter 
            CartLine cartLine = _cartLines.FirstOrDefault(x => x.Product.Id == product.Id);
            //if we find such an Id, the product with its Id and Quantity will be added in to the CartLine object (thus, the object will not be null)
            if (cartLine != null)
            {
                //Update the Quantity with the value of the quantity parameter
                cartLine.Quantity += quantity;
            }
            else
            {
                //if this product is not already in the cart, we create it and add it to the cart
                cartLine = new CartLine
                {
                    Product = product,
                    Quantity = quantity
                };

                _cartLines.Add(cartLine);
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            return null;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
