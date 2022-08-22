using System;
namespace FinalProject.Models
{
    public class FlightProperties
    {
        public FlightProperties()
        {
        }

        public string AirlineName { get; set; }

        public string FlightNumber { get; set; }

        public string Date { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }

        public string FlightDistance { get; set; }

        public string Status { get; set; }

        public string DepartureAirport { get; set; }

        public string ArrivalAirport { get; set; }

        public string ArrivalAirportIATA { get; set; }

        public string DepartureAirportIATA { get; set; }

        public string DepartureCityName { get; set; }


    }
}

