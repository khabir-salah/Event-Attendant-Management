using Attendee.Entities;

namespace Attendee.DTO
{
    public class AttendeeDTO
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

    public class AttendeeRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte Age { get; set; }
    }
}
