namespace Airline.Api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassengerName { get; set; } = string.Empty;
        public string PassportNo{ get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public int status { get; set; } 
    }
}
