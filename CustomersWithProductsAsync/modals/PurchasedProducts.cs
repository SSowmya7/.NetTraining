namespace EFCustomerwithProducts.modals
{
    public class PurchasedProducts
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

       // public List<string> ProductName = new List<string>();
        public List<Product> ProductName { get;set; }//
    }
}
