using System.ComponentModel.DataAnnotations;

namespace EFPractice.Models
{
    public class Customer
    {

        [Key] public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }
}
