using Attendee.Entities;
using System.Linq.Expressions;

namespace Attendee.Repository.Interface
{
    public interface IAttendeeRepository
    {
        void Add(Attendant attandant);
        Task<Attendant> GetAttendant(Expression<Func<Attendant, bool>> predicate);
        Task<ICollection<Attendant>> GetAll();
        Attendant UpdateAttendance(Attendant attendee);
        void RemoveAttendance(Attendant attendee);
        Event UpdateEvent(Event @event);
        void AddEvent(Event @event);
        void RemoveEvent(Event @event);
        Task<ICollection<Event>> GetAllEvents();
        Task<Event> GetEvent(Func<Event, bool> predicate);


    }
}
