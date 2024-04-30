using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPractice
{
    public class ProductUtility
    {
        public static ProductOperations productsOperations = new ProductOperations();
       

        public void DoAdd()
        {

            Product obj = new Product();


            Console.WriteLine("Enter the name of the Product");
            obj.Description = Console.ReadLine();
            Console.WriteLine("Enter the price of the product");
            obj.Price = Convert.ToInt32(Console.ReadLine());
          

            productsOperations.AddProduct(obj);

        }

        public void DoDisplay()
        {
            List<Product> products = productsOperations.DisplayAllProducts();

            foreach (Product prod in products)
            {
                Console.WriteLine("product id: " + prod.ProdId);
                Console.WriteLine("product description: " + prod.Description);
                Console.WriteLine("product price: " + prod.Price);
            }
        }

        public void DoDelete()
        {
            Console.WriteLine("Enter the id of the product to be deleted");
            int id = Convert.ToInt32(Console.ReadLine());
            productsOperations.DeleteProduct(id);
        }

        public void DoUpdate()
        {
            Console.WriteLine("Enter the id of the product to updated");
            int id = Convert.ToInt32(Console.ReadLine());


            Product obj = new Product();

            Console.WriteLine("Enter the name of the product");
            obj.Description = Console.ReadLine();
            Console.WriteLine("Enter the price of the product");
            obj.Price = Convert.ToInt32(Console.ReadLine());
           

            productsOperations.UpdateProduct(id, obj);


        }
    }
}
