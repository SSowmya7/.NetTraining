using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPractice
{
    public class Product
    {
        public int ProdId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
       
        public Product()
        {

        }
        public Product(int prodId, string description, decimal price)
        {
            ProdId = prodId;
            Description = description;
            Price = price;
            
        }


    }
}
