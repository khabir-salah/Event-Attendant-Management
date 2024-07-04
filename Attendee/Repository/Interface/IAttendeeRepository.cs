using Attendee.Entities;
using System.Linq.Expressions;

namespace Attendee.Repository.Interface
{
    public interface IAttendeeRepository
    {
        Task<int> Add(Attendant attandant);
        Task<Attendant> GetAttendant(Expression<Func<Attendant, bool>> predicate);
        Task<ICollection<Attendant>> GetAll();
        Attendant UpdateAttendance(Attendant attendee);

    }
}
