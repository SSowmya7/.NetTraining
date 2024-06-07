using System.ComponentModel.DataAnnotations;

namespace Linq.Data.Models
{
    public class District
    {
         public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int DistrictPopulation { get; set; }
        public int StateId { get; set;}

    }
}
