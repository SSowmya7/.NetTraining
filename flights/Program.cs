namespace flights
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Flight domesticFlight = new DomesticFlight("DF123","BANGALORE", "HYDERABAD");
            Flight internationalFlight = new InternationalFlight("IF123", "CANADA", "INDIA");
            BusinessClassFlight businessClassFlight = new BusinessClassFlight("BCF123", "USA", "CANADA");
            businessClassFlight.UpdateAmenities("Free Wi-Fi, Premium meals");

            // Display flight details
            Console.WriteLine("Domestic Flight Details:");
            Console.WriteLine(domesticFlight.GetFlightDetails());
            Console.WriteLine($"Additional Baggage Allowance: {domesticFlight.AdditionalBaggageAllowance()}");

            Console.WriteLine("\nInternational Flight Details:");
            Console.WriteLine(internationalFlight.GetFlightDetails());
            (internationalFlight as InternationalFlight).VisaRequired = true;
            Console.WriteLine($"Visa Required: {(internationalFlight as InternationalFlight).IsVisaRequired()}");

            Console.WriteLine("\nBusiness Class Flight Details:");
            Console.WriteLine(businessClassFlight.GetFlightDetails());

            // Book seats
            Console.WriteLine("\nBooking 2 seats for Domestic Flight:");
            if (domesticFlight.BookSeat(2))
            {
                Console.WriteLine("Seats booked successfully.");
            }
            else
            {
                Console.WriteLine("Booking failed. No seats available.");
            }
            Console.WriteLine(domesticFlight.GetFlightDetails());
            // Cancel booking
            Console.WriteLine("\nCanceling 1 seat for Domestic Flight:");
            if (domesticFlight.CancelBooking(1))
            {
                Console.WriteLine("Booking canceled successfully.");
            }
            else
            {
                Console.WriteLine("Cancellation failed. No bookings to cancel.");
            }
            Console.WriteLine(domesticFlight.GetFlightDetails());
            // Check flight availability
            Console.WriteLine("\nChecking availability for International Flight:");
            if (internationalFlight.CheckAvailability())
            {
                Console.WriteLine("Seats available.");
            }
            else
            {
                Console.WriteLine("No seats available.");
            }

            // Update additional amenities for Business Class Flight
          //  (businessClassFlight as BusinessClassFlight).UpdateAmenities("Free Wi-Fi, Premium meals");
            

            Console.WriteLine("\nBusiness Class Flight Details after updating amenities:");
            Console.WriteLine((businessClassFlight as BusinessClassFlight).AdditionalAmenities());
        }
    }
}