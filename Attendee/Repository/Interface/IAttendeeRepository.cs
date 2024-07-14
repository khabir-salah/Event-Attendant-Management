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
        Task<Event> GetEvents(Func<Event, bool> predicate);
        Event GetEvent(int id);
        void AddUser(User user);
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUser(Func<User, bool> predicate);
        Task<Role> GetRole(Func<Role, bool> predicate);
    }
}
