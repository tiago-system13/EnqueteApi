using EnqueteApi.Core.Entity;

namespace EnqueteApi.Core.Interfaces
{
    public interface IOptionsRepository
    {
        Option Update(Option option, Option optinOld);

        Option GetbyId(int id);
    }
}
