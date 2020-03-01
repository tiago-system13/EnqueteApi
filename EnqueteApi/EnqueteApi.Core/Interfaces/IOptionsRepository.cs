using EnqueteApi.Core.Entity;

namespace EnqueteApi.Core.Interfaces
{
    public interface IOptionsRepository
    {
        Option Update(Option option);

        Option GetbyId(int id);
    }
}
