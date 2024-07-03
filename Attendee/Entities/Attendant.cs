using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Attendee.Entities
{
    public class Attendant
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
        [ DisplayFormat(DataFormatString = "{yyyy-mm-dd}", ApplyFormatInEditMode = true)]
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
