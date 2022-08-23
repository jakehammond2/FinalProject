using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> DoSomething(FlightProperties flight)
    {
        //var flightprop = new FlightProperties();
        var api = new Api_Get();
        var flights = await api.GetFlight(flight.FlightNumber, flight.Date, flight.userDepartureCity);
        //var flights = await flightTask;
        return View(flights);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

