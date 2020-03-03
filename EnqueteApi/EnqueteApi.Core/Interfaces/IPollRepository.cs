using EnqueteApi.Core.Entity;

namespace EnqueteApi.Core.Interfaces
{
    public interface IPollRepository
    {
        Poll GetbyId(int id);

        Poll Add(Poll poll);

        Poll Update(Poll poll, Poll pollOld);
    }
}
