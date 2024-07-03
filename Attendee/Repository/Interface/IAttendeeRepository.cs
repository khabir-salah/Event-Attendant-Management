using Attendee.Entities;

namespace Attendee.Repository.Interface
{
    public interface IAttendeeRepository
    {
        int Add(Attendant attandant);
        Attendant GetAttendantByName(string name);
        ICollection<Attendant> GetAll();
        Attendant UpdateAttendance(Attendant attendee);

    }
}
