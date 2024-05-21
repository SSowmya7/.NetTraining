using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Data.Models
{
    public class StateWithTotalPopulation
    {
        public string CountryName { get; set; }
        public List<StatePopulation> States { get; set; }
    }
}
