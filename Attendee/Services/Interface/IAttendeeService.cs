using Attendee.DTO;
using Attendee.Entities;

namespace Attendee.Services.Interface
{
    public interface IAttendeeService
    {
        AttendeeDTO Register(AttendeeRequestModel attendant);
        bool IsSteppedOut(string attendant);
        public bool IsCheckedOut(string name);

        bool StepOutOnce(string name);




        AttendeeDTO GetAttendee(string name);

    }
}
