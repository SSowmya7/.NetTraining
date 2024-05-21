using System.ComponentModel.DataAnnotations;

namespace Linq.Data.Models
{
    public class Country
    {
       public int CountryId {  get; set; }
        public string CountryName { get; set; }
        public List<State> States { get; set; } = new List<State>();
    }
}
