using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flights
{
    public class BusinessClassFlight : Flight
    {
        public string Amenities { get; set; }
        public BusinessClassFlight(string FlightNumber, string Origin, String Destination) {

            this.FlightNumber = FlightNumber;
            this.Origin = Origin;
            this.Destination = Destination;
            Capacity = 40; // Set capacity to 40 seats
            BookedSeats = 0;

        }

        //overriding abstract methods
        public override bool CheckAvailability()
        {
            return Capacity - BookedSeats > 0;
        }

        public override bool BookSeat(int seatCount)
        {
            if (Capacity - BookedSeats >= seatCount)
            {
                BookedSeats += seatCount;
                return true;
            }
            return false;
        }

        public override bool CancelBooking(int seatCount)
        {
            if (BookedSeats >= seatCount)
            {
                BookedSeats -= seatCount;
                return true;
            }
            return false;
        }

        //individual method for bussiness class flights class
        public void UpdateAmenities(string newAmenities)
        {
            Amenities = newAmenities;
        }
        public String AdditionalAmenities()
        {
            return Amenities;
        }
    }
  
}
