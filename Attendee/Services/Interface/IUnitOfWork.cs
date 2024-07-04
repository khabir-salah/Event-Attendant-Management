using Attendee.Repository.Interface;

namespace Attendee.Services.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
