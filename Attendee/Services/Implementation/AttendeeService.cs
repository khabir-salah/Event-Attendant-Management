using Attendee.DTO;
using Attendee.Entities;
using Attendee.Repository.Interface;
using Attendee.Services.Interface;

namespace Attendee.Services.Implementation
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IAttendeeRepository _attendeeRepository;
        public AttendeeService(  IAttendeeRepository attendeeRepository ) 
        {
            _attendeeRepository = attendeeRepository;
        }

        
        //public attendeedto checkoutattendee()
        //{
        //    var allattendee = _attendeerepository.getall().where(a => a.departuretime >= datetime.now);
        //   allattendee.select()
        //}

        public AttendeeDTO GetAttendee(string name)
        {
            var get = _attendeeRepository.GetAttendantByName(name);
            if(get != null)
            {
                var attendee = new Attendant
                {
                    FirstName = get.FirstName,
                    LastName = get.LastName,
                    Age = get.Age,
                    ArrivalTime = get.ArrivalTime,
                    DepartureTime = get.DepartureTime,
                    IsCheckedOut = get.IsCheckedOut,
                    IsSteppedOut = get.IsSteppedOut,
                };
                return new AttendeeDTO
                {
                    FirstName = attendee.FirstName,
                    LastName = attendee.LastName,
                    Age = attendee.Age,
                    ArrivalTime = attendee.ArrivalTime,
                    DepartureTime = attendee.DepartureTime,
                    IsCheckedOut = attendee.IsCheckedOut,
                    IsSteppedOut = attendee.IsSteppedOut,
                };
            }
            return null;
            
        }

        public bool IsCheckedOut(string name)
        {
            var checkName = _attendeeRepository.GetAttendantByName(name);
            if(checkName.DepartureTime >= DateTime.Now)
            {
                return true;
            }
            return false;   
        }

        

        public bool IsSteppedOut(string name)
        {
           var checkName = _attendeeRepository.GetAttendantByName(name);
            if(checkName.ArrivalTime >= DateTime.MaxValue.AddMinutes(30))
            {
                return true;
            }
            return false;
        }

        public bool StepOutOnce(string name) 
        {
            var check = _attendeeRepository.GetAttendantByName(name);
            if(check.IsSteppedOut == Status.Returned)
            {
                return true;
            }
            return false;
        }

        

        public AttendeeDTO Register(AttendeeRequestModel attendant)
        {
            var isExit = GetAttendee(attendant.FirstName);
            if(isExit == null)
            {
                var attendee = new Attendant
                {
                    FirstName = attendant.FirstName,
                    LastName = attendant.LastName,
                    Age = attendant.Age,
                    ArrivalTime = DateTime.Now,
                    DepartureTime = Event.EventEndTime,
                    IsCheckedOut = false,
                    IsSteppedOut = Status.Inside,
                };
                _attendeeRepository.Add(attendee);
                return new AttendeeDTO
                {
                    FirstName = attendee.FirstName,
                    LastName = attendee.LastName,
                    Age = attendee.Age,
                    ArrivalTime = DateTime.Now,
                    DepartureTime = Event.EventEndTime,
                    IsCheckedOut= IsCheckedOut(attendee.FirstName),
                    IsSteppedOut = Status.Inside
                };
            }
            return null;
        }

       

       
    }
}
