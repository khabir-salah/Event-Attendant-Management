
using Microsoft.EntityFrameworkCore;
using Attendee.Entities;
namespace Attendee.Context
{
    public class AttendeeContext : DbContext
    {
        public AttendeeContext(DbContextOptions<AttendeeContext> options) : base(options)
        {

        }


        public DbSet<Attendant>  attendees { get; set; }
    }

    
}
