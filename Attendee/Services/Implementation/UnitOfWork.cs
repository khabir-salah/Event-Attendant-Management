using Attendee.Context;
using Attendee.Repository.Implementation;
using Attendee.Repository.Interface;
using Attendee.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Attendee.Services.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AttendeeContext _context;
        public UnitOfWork(AttendeeContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

