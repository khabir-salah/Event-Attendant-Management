
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
        public int Id { get; set; }
        public string name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public  DateTime EventStartTime { get; set; } = default!;
        public  DateTime EventEndTime { get; set; } = default!;
    }

    public enum Status
    {
        Inside,
        Outside,
        Returned
    }

   
}
