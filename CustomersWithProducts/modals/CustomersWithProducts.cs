
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCustomerwithProducts.modals
{
    public class CustomersWithProduct
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
       public int ProductId { get; set; }
      
    }
}
