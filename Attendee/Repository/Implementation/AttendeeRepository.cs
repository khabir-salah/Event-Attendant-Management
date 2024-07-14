using Attendee.Context;
using Attendee.Entities;
using Attendee.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Attendee.Repository.Implementation
{
    public class AttendeeRepository : IAttendeeRepository

    {
        private readonly AttendeeContext _context;
        public AttendeeRepository( AttendeeContext context ) 
        {
            _context = context;
        }

        public void Add(Attendant attandant)
        {
           _context.attendees.AddAsync( attandant );
        }

        public void AddEvent(Event @event)
        {
            _context.Events.AddAsync(@event);
        }

        public async Task<ICollection<Attendant>> GetAll()
        {
            return await _context.attendees.ToListAsync();
        }

        public async Task<ICollection<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Attendant?> GetAttendant(Expression<Func<Attendant, bool>> predicate)
        {
            return await _context.attendees.FindAsync(predicate);
        }

        public async Task<Event?> GetEvents(Func<Event, bool> predicate)
        {
            return await _context.Events.FindAsync(predicate);
        }

        public Event? GetEvent(int id)
        {
            return _context.Events.Find(id);
        }

        public void RemoveAttendance(Attendant attendee)
        {
            _context.attendees.Remove(attendee);
        }

        public void RemoveEvent(Event @event)
        {
             _context.Events.Remove(@event);
        }

        public Attendant UpdateAttendance(Attendant attendee)
        {
           _context.attendees.Update(attendee);
            return attendee;
        }

        public Event UpdateEvent(Event @event)
        {
            _context.Events.Update(@event);
            return @event;
        }
    }
}
