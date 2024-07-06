using Attendee.DTO;
using Attendee.Entities;

namespace Attendee.Services.Interface
{
    public interface IAttendeeService
    {
        Task<AttendeeDTO> Register(AttendeeRequestModel attendant);
        Task<AttendeeDTO> SignOutAttendee(int Id);
        Task<bool> IsSteppedOut(string attendant);
        Task<bool> IsCheckedOut(string name);
        Task<bool> StepOutOnce(string name);
        Task<AttendeeDTO> GetAttendee(string name);

        Task<ICollection<AttendeeDTO>> AttendeeDetails();
        Task<ICollection<AttendeeDTO>> TempStepOutAttendee();
        Task<ICollection<AttendeeDTO>> DeniedStepOut();
        Task<ICollection<AttendeeDTO>> AttendeePresent();
        Task<ICollection<AttendeeDTO>> SuccessfullStepOut();
        Task<EventResponseModel> RegisterEvent(EventRequestModel requestModel);
        EventResponseModel UpdateEvent(EventRequestModel requestModel);
        Task<ICollection<EventResponseModel>> GetAllEvent();


    }
}
