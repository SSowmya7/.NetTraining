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





        // customer with purchased products Asynchronous

        [HttpGet("/CustomersWithPurchasedProducts")]

        public async Task<ActionResult<IEnumerable<PurchasedProducts>>> Get()
        {
            PurchasedProducts purchasedProducts = new PurchasedProducts();
            var customerPurchasedProducts = new List<PurchasedProducts>();


            var customersWithProducts = await context.CustomersWithProduct.ToListAsync();
            var customers = await context.Customers.ToListAsync();
            var products = await context.Products.ToListAsync();

            foreach (var customer in customers)
            {

                var CurrentCustomerDetails = customersWithProducts.Where(cp => cp.CustomerId == customer.CustomerId);

                var customerProductInfo = new PurchasedProducts
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    ProductName = new List<Product>()
                };


                foreach (var costumerProduct in CurrentCustomerDetails)
                {
                    var product = products.Find(p => p.ProductId == costumerProduct.ProductId);

                    if (product != null)
                    {
                        customerProductInfo.ProductName.Add(product);
                    }
                }
                customerPurchasedProducts.Add(customerProductInfo);


            }
            return customerPurchasedProducts;
        }























    }
}
