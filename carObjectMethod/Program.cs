using System;

namespace YourNamespace
{
    class Car
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public void CarInfo()
        {
            Console.WriteLine($"Car- Manufacturer : {Manufacturer},Model : {Model},Year : {Year}"
                + " hey hello how do uh do ");
        }
    }

    class Program
    {
        static void Main()
        {
            Car car1 = new Car();
            car1.Manufacturer = "Alice";
            car1.Model = "XUV";
            car1.Year = 2024;

            car1.CarInfo();
        }
    }

}

