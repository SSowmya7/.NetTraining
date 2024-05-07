using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace flights
{

    public class DomesticFlight : Flight
    {
        public int BaggageAllowance { get; set; }
         

        public DomesticFlight( string FlightNumber,string Origin,String Destination)
        {
            this.FlightNumber = FlightNumber;
            this.Origin = Origin;
            this.Destination = Destination;
            Capacity = 60; // Set capacity to 60 seats
            BookedSeats = 0;
            BaggageAllowance = 24;
        }
  
        //abstract methods overriding
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

        //virtual method Overriding
        public override string AdditionalBaggageAllowance()
        {
            return "Allowed 2kgs per ticket on paying $200  ";
        }

        // individual method of domesticflights class
        public bool IsWeightAllowed(int weight) {
            return BaggageAllowance <= weight;
        }
    }
}
