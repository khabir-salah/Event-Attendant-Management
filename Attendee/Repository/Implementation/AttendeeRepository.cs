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

        public async Task< int> Add(Attendant attandant)
        {
           _context.attendees.AddAsync( attandant );
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Attendant>> GetAll()
        {
            return await _context.attendees.ToListAsync();
        }

        public async Task<Attendant?> GetAttendant(Expression<Func<Attendant, bool>> predicate)
        {
            return await _context.attendees.FindAsync(predicate);
        }


        public Attendant UpdateAttendance(Attendant attendee)
        {
           _context.attendees.Update(attendee);
            return attendee;
        }

        
    }
}
