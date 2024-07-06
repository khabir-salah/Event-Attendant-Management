using Attendee.Entities;
using System.ComponentModel.DataAnnotations;

namespace Attendee.DTO
{
    public class AttendeeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "must fill"), MinLength(3, ErrorMessage = "more yhan 3 letters needed"), MaxLength(15, ErrorMessage = "less than 15")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "must fill"), MinLength(3, ErrorMessage = "more yhan 3 letters needed"), MaxLength(15, ErrorMessage = "less than 15")]
        public string? LastName { get; set; }
        [Required]
        public byte Age { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd}", ApplyFormatInEditMode = true)]
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

    public class EventRequestModel
    {
        public int Id { get; set; }
        public string name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public  DateTime EventStartTime { get; set; } = default!;
        public  DateTime EventEndTime { get; set; } = default!;
    }

    public class EventResponseModel
    {
        public string name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public  DateTime EventStartTime { get; set; } = default!;
        public  DateTime EventEndTime { get; set; } = default!;
    }
}
