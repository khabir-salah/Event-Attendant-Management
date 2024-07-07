using Attendee.DTO;
using Attendee.Entities;
using Attendee.Repository.Interface;
using Attendee.Services.Interface;
using System.Linq;

namespace Attendee.Services.Implementation
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IAttendeeRepository _attendeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AttendeeService(  IAttendeeRepository attendeeRepository, IUnitOfWork unitOfWork) 
        {
            _attendeeRepository = attendeeRepository;
            _unitOfWork = unitOfWork;
        }

        
        //public attendeedto checkoutattendee()
        //{
        //    var allattendee = _attendeerepository.getall().where(a => a.departuretime >= datetime.now);
        //   allattendee.select()
        //}

        public async Task<AttendeeDTO> GetAttendee(string name)
        {
            var get = await _attendeeRepository.GetAttendant(a => a.FirstName.Contains(name) || a.LastName.Contains(name));
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

        public async Task<bool> IsCheckedOut(string name)
        {
            var checkName = await  _attendeeRepository.GetAttendant(a => a.FirstName.Contains(name) || a.LastName.Contains(name));
            if(checkName.DepartureTime >= DateTime.Now)
            {
                return true;
            }
            return false;   
        }

        

        public async Task<bool> IsSteppedOut(string name)
        {
           var checkName = await _attendeeRepository.GetAttendant(a => a.FirstName.Contains(name) || a.LastName.Contains(name));
            if(checkName.ArrivalTime >= DateTime.MaxValue.AddMinutes(30))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> StepOutOnce(string name) 
        {
            var check = await _attendeeRepository.GetAttendant(a => a.FirstName.Contains(name) || a.LastName.Contains(name));
            if(check.IsSteppedOut == Status.Returned)
            {
                return true;
            }
            return false;
        }

        

        public async Task<AttendeeDTO> Register(AttendeeRequestModel attendant)
        {
            var isExit = await GetAttendee(attendant.FirstName);
            if(isExit == null)
            {
                var attendee = new Attendant
                {
                    FirstName = attendant.FirstName,
                    LastName = attendant.LastName,
                    Age = attendant.Age,
                    ArrivalTime = DateTime.Now,
                    IsCheckedOut = false,
                    IsSteppedOut = Status.Inside,
                };
                _attendeeRepository.Add(attendee);
                _unitOfWork.SaveChanges();
                return new AttendeeDTO
                {
                    FirstName = attendee.FirstName,
                    LastName = attendee.LastName,
                    Age = attendee.Age,
                    ArrivalTime = DateTime.Now,
                    IsCheckedOut = false,
                    IsSteppedOut = Status.Inside
                };
            }
            return null;
        }


        public async Task<ICollection<AttendeeDTO>> AttendeeDetails()
        {
            var allAttendee = await _attendeeRepository.GetAll();
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

        public async Task<ICollection<AttendeeDTO>> AttendeePresent()
        {
            var attendeeList = new List<AttendeeDTO>();
            var attendee = await _attendeeRepository.GetAll();
            var asd = attendee.Where(x => x.IsSteppedOut == Entities.Status.Returned && x.IsSteppedOut == Entities.Status.Inside);
            foreach (var item in asd)
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

        public Task<ICollection<AttendeeDTO>> DeniedStepOut()
        {
            throw new NotImplementedException();
        }



        public async Task<ICollection<AttendeeDTO>> SuccessfullStepOut()
        {
            var attendeeList = new List<AttendeeDTO>();
            var attendee = await _attendeeRepository.GetAll();
            var asd = attendee.Where(x => x.IsSteppedOut == Entities.Status.Outside && x.IsSteppedOut == Entities.Status.Returned);
            foreach (var item in asd)
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

        public async Task<ICollection<AttendeeDTO>> TempStepOutAttendee()
        {
            var attendeeList = new List<AttendeeDTO>();
            var attendee = await _attendeeRepository.GetAll();
            var asd = attendee.Where(x => x.IsSteppedOut == Entities.Status.Outside);
            foreach (var item in asd)
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

        public async Task<EventResponseModel> RegisterEvent(EventRequestModel requestModel)
        {

            var checkTime = await _attendeeRepository.GetEvent(e => requestModel.EventStartTime < e.EventEndTime && requestModel.EventEndTime > e.EventStartTime);
            if(checkTime == null)
            {
                var newEvent = new Event
                {
                    name = requestModel.name,
                    Description = requestModel.Description,
                    EventStartTime = requestModel.EventStartTime,
                    EventEndTime = requestModel.EventEndTime,
                };
                _attendeeRepository.AddEvent(newEvent);
                _unitOfWork.SaveChanges();
                return new EventResponseModel
                {
                    name = newEvent.name,
                    Description = newEvent.Description,
                    EventStartTime = newEvent.EventStartTime,
                    EventEndTime = newEvent.EventEndTime,
                };
            }
            return null;
        }

        public EventResponseModel UpdateEvent(EventRequestModel requestModel)
        {
            var isEventExist = _attendeeRepository.GetEvent(e => e.Id == requestModel.Id);
            if(isEventExist != null)
            {
                var updatedEvent = new EventResponseModel
                {
                    name = requestModel.name,
                    Description = requestModel.Description,
                    EventStartTime = requestModel.EventStartTime,
                    EventEndTime = requestModel.EventEndTime,
                };
                _attendeeRepository.UpdateEvent(isEventExist); return updatedEvent;
            }
            return null;
        }

        public async Task<ICollection<EventResponseModel>> GetAllEvent()
        {
            var allEvent = _attendeeRepository.GetAllEvents();
            var data = ( await allEvent).Select(s => new EventResponseModel
            {
                name = s.name,
                Description = s.Description,
                EventEndTime = s.EventEndTime,
                EventStartTime = s.EventStartTime,
            }).ToList();
            return data;
        }

        public async Task<AttendeeDTO> SignOutAttendee(int Id)
        {
            var attendee = await _attendeeRepository.GetAttendant(a => a.Id == Id);
            if(attendee != null)
            {
                attendee.DepartureTime = DateTime.UtcNow;
                _attendeeRepository.UpdateAttendance(attendee);
            }
            return null;
            
        }
    }
}
