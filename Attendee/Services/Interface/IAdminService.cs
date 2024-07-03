using Attendee.DTO;

namespace Attendee.Services.Interface
{
    public interface IAdminService
    {
        ICollection<AttendeeDTO> AttendeeDetails();
        ICollection<AttendeeDTO> TempStepOutAttendee();
        ICollection<AttendeeDTO> DeniedStepOut();
        ICollection<AttendeeDTO> AttendeePresent();
        ICollection<AttendeeDTO> SuccessfullStepOut();

    }
}
