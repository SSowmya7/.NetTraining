using Linq.Data.Models;

namespace LinqAssignment.Services
{
    public class LinqQueiries
    {
        List<Country> countries;
        public LinqQueiries()
        {
            DataGenerator dataGenerator = new DataGenerator();

            countries = dataGenerator.GetCountries();
        }

        public Country AddCountry()
        {
            // Add a new Country called "MyOwn"
            var myOwnCountry = new Country { CountryId = 4, CountryName = "MyOwn" };
            countries.Add(myOwnCountry);

            // Add a range of 10 states to "MyOwn" country with each state having 10 districts
            for (int i = 1; i <= 10; i++)
            {
                var state = new State { StateId = 100 + i, StateName = $"State{i}", CountryId = 4 };
                myOwnCountry.States.Add(state);

                for (int j = 1; j <= 10; j++)
                {
                    var district = new District
                    {
                        DistrictId = (i - 1) * 10 + j + 1000,
                        DistrictName = $"State{i}District{j}",
                        StateId = 100 + i,
                        DistrictPopulation = new Random().Next(1000, 10000)
                    };
                    state.Districts.Add(district);
                }
            }
            return myOwnCountry;
        }
        public List<Country> GetAllCountries()
        {
            return countries;
        }
        public List<State> GetAllStatesofCountry()
        {
            return countries.SelectMany(c => c.States).ToList();

        }

        public List<District> GetDistricts()
        {
            return countries.SelectMany(c => c.States)
                  .SelectMany(s => s.Districts)
                  .ToList();
        }

        public List<StateWithTotalPopulation> GetStatesWithTotalPopulation()
        {
            return countries.Select(country => new StateWithTotalPopulation
            {
                CountryName = country.CountryName,
                States = country.States.Select(state => new StatePopulation
                {
                    StateName = state.StateName,
                    TotalPopulation = state.Districts.Sum(district => district.DistrictPopulation)
                }).ToList()
            }).ToList();
        }



        public List<CountryWithTotalPopulation> GetCountriesWithTotalPopulation()
        {
            return countries.Select(country => new CountryWithTotalPopulation
            {
                CountryName = country.CountryName,
                TotalPopulation = country.States.Sum(state => state.Districts.Sum(district => district.DistrictPopulation))
            }).ToList();
        }

        public List<District> GetTop5MostPopulatedDistricts()
        {
            return countries.SelectMany(c => c.States)
                            .SelectMany(s => s.Districts)
                            .OrderByDescending(d => d.DistrictPopulation)
                            .Take(5)
                            .ToList();
        }
        public Dictionary<string, List<District>> GetTopDistrictsPerState()
        {
            return countries.ToDictionary(country => country.CountryName, country =>
            {
                return country.States.SelectMany(state => state.Districts)
                              .OrderByDescending(d => d.DistrictPopulation)
                              .Take(2)
                              .ToList();
            });
        }


        public Country GetMostPopulatedCountry()
        {
            return countries.OrderByDescending(c => c.States.
            Sum(state => state.Districts.Sum(district => district.DistrictPopulation)))
                            .FirstOrDefault();
        }



        public Country GetFirstCountryWithTwoVowels()
        {
            return countries.Where(c => CountVowels(c.CountryName) >= 2)
                            .FirstOrDefault();
        }

        private int CountVowels(string name)
        {
            int vowelCount = 0;
            foreach (char ch in name.ToLower())
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                {
                    vowelCount++;
                }
            }
            return vowelCount;
        }

        public Country GetFirstCountryWithTwoVowelsOrderByName()
        {
            return countries.OrderBy(country => country.CountryName)
                .Where(c => CountVowels(c.CountryName) >= 2)
                            .FirstOrDefault();
        }
        public int StateCount()
        {
            var countriesWithStateCount = countries.SelectMany(c => c.States).ToList();
            return countriesWithStateCount.Count();
        }

        public int DistrictCount()
        {
            var countriesWithDistrictCount = countries.SelectMany(c => c.States)
                  .SelectMany(s => s.Districts)
                  .ToList();
            return countriesWithDistrictCount.Count();
        }

        public IEnumerable<Country> Nostates()
        {
            var CountriesWithNoStates = countries.Where(c => c.States == null);
                 

            return CountriesWithNoStates;
        }

        public List<State> NoDistricts()
        {
            var CountriesWithNoDistricts = countries.SelectMany(c => c.States)
                  .Where(s => s.Districts == null)
                  .ToList();
            return CountriesWithNoDistricts;
        }



        public List<District> DistrictsWithPopulation500()
        {
            var countriesWithDistrictCount = countries.SelectMany(c => c.States)
                .SelectMany(s => s.Districts).Where(d => d.DistrictPopulation >= 500).ToList();
            return countriesWithDistrictCount;

        }

        public List<State> StatesWithDistrictsGreaterThan5()
        {
            var StatesWithDistrictsGreaterThan5 = countries.SelectMany(c => c.States)
                  .Where(s => s.Districts.Count >= 5)
                  .ToList();
            return StatesWithDistrictsGreaterThan5;
        }
        public List<Country> CountriesWithStatesGreaterThan5()
        {
            var CountriesWithStatesGreaterThan5 =countries
                  .Where(s => s.States.Count >= 5)
                  .ToList();
            return CountriesWithStatesGreaterThan5;
        }

    }
}
