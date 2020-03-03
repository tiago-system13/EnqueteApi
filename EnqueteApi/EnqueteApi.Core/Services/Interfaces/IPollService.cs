using EnqueteApi.Core.Entity;

namespace EnqueteApi.Core.Services.Interfaces
{
    public interface IPollService
    {
        Poll GetbyId(int id, bool calledByGetPollId);

        Poll Add(Poll poll);
    }
}
