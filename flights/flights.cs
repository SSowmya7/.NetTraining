using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace flights
{
    public abstract class Flight
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Capacity { get; set; }
        public int BookedSeats { get; set; }

        //abstract methods
        public abstract bool CheckAvailability();
        public abstract bool BookSeat(int seatCount);
        public abstract bool CancelBooking(int seatCount);
       // virtual methods
        public virtual  string CheckFlightStatus()
        {
            return "On Time";
        }
        public virtual string AdditionalBaggageAllowance()
        {
            return "Not Allowed";
        }

        //individual method
        public string GetFlightDetails()
        {
            return $"Flight Number: {FlightNumber}\n" +
           $"Origin: {Origin}\n" +
           $"Destination: {Destination}\n" +
           $"Capacity: {Capacity}\n" +
           $"Booked Seats: {BookedSeats}\n";
        }
    }
}
