using System.ComponentModel.DataAnnotations;

namespace EFCustomerwithProducts.modals
{
    public class Product
    {
        [Key] public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

    }
}
