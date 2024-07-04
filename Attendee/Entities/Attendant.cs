
namespace Attendee.Entities
{
    public class Attendant
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte Age { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public bool IsCheckedOut { get; set; }
        public Status IsSteppedOut { get; set; }
       
    }

    public class Event
    {
        public static DateTime EventStartTime { get;  } = DateTime.Now;
        public static DateTime EventEndTime { get; } =  DateTime.Now.AddHours(1);
    }

    public enum Status
    {
        Inside,
        Outside,
        Returned
    }

   
}
