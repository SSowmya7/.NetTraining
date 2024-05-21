using System.ComponentModel.DataAnnotations;

namespace Linq.Data.Models
{
    public class State
    {
       public int StateId { get; set; }
       public string StateName { get; set; }
       public int CountryId { get; set; }
        public List<District> Districts { get; set; } = new List<District>();
    }
}
