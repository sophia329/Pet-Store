using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Domain.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    // Cart Operations 
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        // Access the content of the cart
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void AddItem(Product myproduct, int myquantity)
        {
            CartLine line = lineCollection
                            .Where(p => p.Product.ProductID == myproduct.ProductID)
                            .FirstOrDefault();

            // Adding a new item to the cart
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = myproduct,
                    Quantity = myquantity
                });
            }

            // For item that already exist in the cart, just increase the quantity.
            else
            {
                line.Quantity += myquantity;
            }
        }

        // Remove a product
        public void RemoveLine(Product myproduct)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == myproduct.ProductID);
        }

        // Compute total cost of cart
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        // Reset the cart
        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
