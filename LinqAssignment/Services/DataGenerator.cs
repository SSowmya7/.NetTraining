using Linq.Data.Models;

namespace LinqAssignment.Services
{
    public  class DataGenerator
    {
        public  List<Country> GetCountries()
        {
            var countries = new List<Country>();

            var country1 = new Country { CountryId = 1, CountryName = "Country1" };
            var country2 = new Country { CountryId = 2, CountryName = "Country2" };
            var country3 = new Country { CountryId = 3, CountryName = "Country3" };

            countries.Add(country1);
            countries.Add(country2);
            countries.Add(country3);

            for (int i = 1; i <= 10; i++)
            {
                var state = new State { StateId = i, StateName = $"State{i}", CountryId = 1 };
                country1.States.Add(state);

                for (int j = 1; j <= 10; j++)
                {
                    var district = new District
                    {
                        DistrictId = (i - 1) * 10 + j,
                        DistrictName = $"State{i}District{j}",
                        StateId = i,
                        DistrictPopulation = new Random().Next(1000, 10000)
                    };
                    state.Districts.Add(district);
                }
            }

            return countries;
        }
    }

}
