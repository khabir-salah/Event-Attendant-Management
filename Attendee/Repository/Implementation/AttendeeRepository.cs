using Attendee.Context;
using Attendee.Entities;
using Attendee.Repository.Interface;

namespace Attendee.Repository.Implementation
{
    public class AttendeeRepository : IAttendeeRepository

    {
        private readonly AttendeeContext _context;
        public AttendeeRepository( AttendeeContext context ) 
        {
            _context = context;
        }
        public int Add(Attendant attandant)
        {
           _context.Add( attandant );
            return _context.SaveChanges();
        }

        public ICollection<Attendant> GetAll()
        {
            return _context.attendees.ToList();
        }

        public Attendant? GetAttendantByName(string name)
        {
           var attendee = _context.attendees.SingleOrDefault(a => a.FirstName == name);
            return attendee;
        }

        public Attendant UpdateAttendance(Attendant attendee)
        {
           _context.attendees.Update(attendee);
            return attendee;
        }

        
    }
}
