using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flights
{
   public class InternationalFlight : Flight

    {
        public bool VisaRequired { get; set; }
        //constructor
        public InternationalFlight(string FlightNumber, string Origin, String Destination) {
            this.FlightNumber = FlightNumber;
            this.Origin = Origin;
            this.Destination = Destination;
            Capacity = 120; // Set capacity to 120 seats
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

        //overriding virtual method
   public override string CheckFlightStatus()
   {
           
        return "Delayed";
   }

        // individual method of international flights class
        public bool IsVisaRequired()
        {
            return VisaRequired;
        }
    }
}
