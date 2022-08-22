using System;
using System.Globalization;
using FinalProject.Models;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.TimeSpan;

public class Api_Get

{
    public async Task<FlightProperties> GetFlight(string flightNum, string date, string userDepartureCity)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://aerodatabox.p.rapidapi.com/flights/number/{flightNum}/{date}"),
            Headers =
                {
                    { "X-RapidAPI-Key", "fa96296f46mshcae55558b128d47p1b35d1jsn2a266e359194" },
                    { "X-RapidAPI-Host", "aerodatabox.p.rapidapi.com" },
                },
        };

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var json = JArray.Parse(body);

            string departureTime = "";
            string arrivalTime = "";
            string airlineName = "";
            string flightDistance = "";
            string status = "";
            string departureAirport = "";
            string arrivalAirport = "";
            string flightNumber = "";
            string arrivalAirportIATA = "";
            string departureAirportIATA = "";
            string departureCityName = "";
            FlightProperties singleFlight = null; 

            foreach (var type in json)
            {

                //Console.WriteLine(type);
                departureTime = type["departure"]["scheduledTimeLocal"].ToString().Split(' ').Last().Split('-').First();
                arrivalTime = type["arrival"]["scheduledTimeLocal"].ToString().Split(' ').Last().Split('-').First();
                departureAirport = type["departure"]["airport"]["name"].ToString();
                airlineName = type["airline"]["name"].ToString();
                flightDistance = type["greatCircleDistance"]["mile"].ToString();
                status = type["status"].ToString();
                arrivalAirport = type["arrival"]["airport"]["name"].ToString();
                flightNumber = type["number"].ToString();
                arrivalAirportIATA = type["arrival"]["airport"]["iata"].ToString();
                departureAirportIATA = type["departure"]["airport"]["iata"].ToString();
                departureCityName = type["departure"]["airport"]["municipalityName"].ToString();

                if (departureCityName == userDepartureCity)
                {
                    singleFlight = new FlightProperties()
                    {
                        AirlineName = airlineName,
                        DepartureTime = departureTime,
                        DepartureAirport = departureAirport,
                        FlightDistance = flightDistance,
                        Status = status,
                        ArrivalTime = arrivalTime,
                        ArrivalAirport = arrivalAirport,
                        FlightNumber = flightNumber,
                        DepartureAirportIATA = departureAirportIATA,
                        ArrivalAirportIATA = arrivalAirportIATA,
                    };
                  
                }

            }
            return singleFlight;
        }
    }
} 
