
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
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                
                new Role { Id = 101, Name = "Manager" },
                new Role { Id = 102, Name = "Attendee" }
            );
        }
    }

    
}
