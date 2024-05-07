using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPractice
{
    public class ProductOperations
    {
        private List<Product> products = new List<Product>();

        private int nextId = 1;

        public void AddProduct(Product product)


        {
           products.Add(new Product(nextId,product.Description,product.Price));
            nextId++;

        }

        public void UpdateProduct(int id, Product obj)
        {

            foreach (Product prod in products)
            {
                if (prod.ProdId == id)
                {
                    prod.Description = obj.Description;
                    prod.Price = obj.Price;
        
                    break;
                }
            }
        }

        public void DeleteProduct(int id)
        {
            products.RemoveAt((id - 1));
        }
        public List<Product> DisplayAllProducts()
        {

            return products;
        }
    }
}
