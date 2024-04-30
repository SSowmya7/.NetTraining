using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flights
{
    public sealed class SpecialBusinessClassFlights :Flight
    {
        public string SpecialAmenities { get; set; }


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

        //sealed method
        public sealed override bool CancelBooking(int seatCount)
        {
            if (BookedSeats >= seatCount)
            {
                BookedSeats -= seatCount;
                return true;
            }
            return false;
        }
        //individual method for Specialbussiness class flights class

        public  String PremiumlAmenities()
        {
            return SpecialAmenities;
        }
    }
}
