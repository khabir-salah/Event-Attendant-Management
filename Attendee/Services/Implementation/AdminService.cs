using Attendee.DTO;
using Attendee.Repository.Interface;
using Attendee.Services.Interface;

namespace Attendee.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IAttendeeRepository _repository;
        public AdminService(IAttendeeRepository repository)
        {
            _repository = repository;
        }

        public ICollection<AttendeeDTO> AttendeeDetails()
        {
           var allAttendee = _repository.GetAll();
            var attendeeList = allAttendee.Select(x => new AttendeeDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
                ArrivalTime = x.ArrivalTime,
                DepartureTime = x.DepartureTime,
                IsCheckedOut = x.IsCheckedOut,
                IsSteppedOut = x.IsSteppedOut
            }).ToList();
            return attendeeList;
        }

        public ICollection<AttendeeDTO> AttendeePresent()
        {
            var attendeeList = new List<AttendeeDTO>();
            var attendee = _repository.GetAll().Where(x => x.IsSteppedOut == Entities.Status.Returned && x.IsSteppedOut == Entities.Status.Inside );
           foreach(var item in attendee)
            {
                var attendant = new AttendeeDTO
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    ArrivalTime = item.ArrivalTime,
                    DepartureTime = item.DepartureTime,
                    IsCheckedOut = item.IsCheckedOut,
                    IsSteppedOut = item.IsSteppedOut,
                };
                attendeeList.Add(attendant);
            }
            return attendeeList;
        }

        public ICollection<AttendeeDTO> DeniedStepOut()
        {
            throw new NotImplementedException();
        }

        

        public ICollection<AttendeeDTO> SuccessfullStepOut()
        {
            var attendeeList = new List<AttendeeDTO>();
            var attendee = _repository.GetAll().Where(x => x.IsSteppedOut == Entities.Status.Outside && x.IsSteppedOut == Entities.Status.Returned);
            foreach (var item in attendee)
            {
                var attendant = new AttendeeDTO
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    ArrivalTime = item.ArrivalTime,
                    DepartureTime = item.DepartureTime,
                    IsCheckedOut = item.IsCheckedOut,
                    IsSteppedOut = item.IsSteppedOut,
                };
                attendeeList.Add(attendant);
            }
            return attendeeList;
        }

        public ICollection<AttendeeDTO> TempStepOutAttendee()
        {
            var attendeeList = new List<AttendeeDTO>();
            var attendee = _repository.GetAll().Where(x => x.IsSteppedOut == Entities.Status.Outside);
            foreach (var item in attendee)
            {
                var attendant = new AttendeeDTO
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    ArrivalTime = item.ArrivalTime,
                    DepartureTime = item.DepartureTime,
                    IsCheckedOut = item.IsCheckedOut,
                    IsSteppedOut = item.IsSteppedOut
                };
                attendeeList.Add(attendant);
            }
            return attendeeList;
        }
    }
}
