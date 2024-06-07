using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFCustomerwithProducts.Data;
using EFCustomerwithProducts.modals;
using Microsoft.EntityFrameworkCore;


namespace EFCustomerwithProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        PrjContext context;
        List<PurchasedProducts> customerProducts = new List<PurchasedProducts>();
        
        
        public CustomerController(PrjContext prjContext)
        {
            context = prjContext;
        }



        //Customer Controller General crud

        //[HttpGet]
        //public List<Customer> Get()
        //{
        //    return context.Customers.ToList<Customer>();
        //}

        //[HttpPost]
        //public string Post([FromBody] Customer customer)
        //{
        //    context.Customers.Add(customer);
        //    context.SaveChanges();
        //    return "Customer Record Created Successfully";
        //}


        //[HttpPut]
        //public string Put([FromBody] Customer customer)
        //{
        //    context.Customers.Update(customer);
        //    context.SaveChanges();
        //    return "Customer record updates succesfully";
        //}


        //[HttpPost]
        //public string Post([FromBody] CustomersWithProduct cusProd)
        //{
        //    context.CustomersWithProduct.Add(cusProd);
        //    context.SaveChanges();
        //    return "Customer  prod Record Created Successfully";
        //}
        //[HttpDelete]
        //public string Delete(int id)
        //{
        //    var customerToDelete = context.Customers.Find(id);
        //    if (customerToDelete != null)
        //    {
        //        context.Customers.Remove(customerToDelete);
        //        context.SaveChanges();
        //        return "Customer record deleted successfully";
        //    }
        //    else
        //    {
        //        return "Customer not found";
        //    }
        //}





        // customer with purchased products synchronous

        [HttpGet("/CustomersWithPurchasedProducts")]

        public List<PurchasedProducts> Get()
        {
            var customersWithProducts = context.CustomersWithProduct.ToList();

            foreach (var customerProduct in customersWithProducts)
            {
                PurchasedProducts customer = new PurchasedProducts();
                customer.ProductName = new List<string>();

                customer.CustomerName = context.Customers.Find(customerProduct.CustomerId)?.CustomerName;
                string Product = context.Products.Find(customerProduct.ProductId)?.ProductName;
                customer.ProductName.Add(Product);

                customerProducts.Add(customer);

            }

            return customerProducts;

        }





    }
}
