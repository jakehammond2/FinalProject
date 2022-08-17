using System.ComponentModel.DataAnnotations;

namespace FinalProject_FlightTracker.Models
{
    public class FlightInfo
    {
        [Required]
        [DataType(DataType.Text)]

        public string FlightNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }

    }
}
