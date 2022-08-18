using FinalProject.Models;
using Newtonsoft.Json.Linq;

public class Api_Get

{
    //public async void getAPIAsync()
    //{
    //    Console.WriteLine("Please enter in your specific flight number.");
    //    var flightNumber = Console.ReadLine();

    //    Console.WriteLine("Please enter in your flight date in YYYY-MM-DD.");
    //    var date = Console.ReadLine();

    //var client = new HttpClient();
    //var request = new HttpRequestMessage
    //{
    //    Method = HttpMethod.Get,
    //    RequestUri = new Uri($"https://aerodatabox.p.rapidapi.com/flights/%7BsearchBy%7D/{flightNumber}/{date}"),
    //    Headers =
    //{
    //    { "X-RapidAPI-Key", "fa96296f46mshcae55558b128d47p1b35d1jsn2a266e359194" },
    //    { "X-RapidAPI-Host", "aerodatabox.p.rapidapi.com" },
    //},
    //};
    //    using (var response = await client.SendAsync(request))
    //    {
    //        response.EnsureSuccessStatusCode();
    //        var body = await response.Content.ReadAsStringAsync();
    //        Console.WriteLine(body);
    //    }
    //}

    public async Task<FlightProperties> GetFlight(string flightNum, string date)
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

            foreach(var type in json)
            {
                departureTime = type["departure"]["scheduledTimeLocal"].ToString();
                airlineName = type["airline"]["name"].ToString();
                flightDistance = type["greatCircleDistance"]["mile"].ToString();
                status = type["status"].ToString();
                //arrivalTime = type["arrival"]["scheduledTimeLocal"].ToString();

            }
            var singleFlight = new FlightProperties()
            {
                AirlineName = airlineName,
                DepartureTime = departureTime,
                FlightDistance = flightDistance,
                Status = status
                //ArrivalTime = arrivalTime,
                //FlightNumber = (string?)json[0]["number"],
            };
            return singleFlight;

        }
        

    }
} 
