using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Data.Context;
using System.Linq;

namespace EnqueteApi.Data.Repository
{
    public class OptionRepository : IOptionsRepository
    {
        private readonly EnqueteApiContext _context;

        public OptionRepository(EnqueteApiContext context)
        {
            _context = context;
        }

        public Option GetbyId(int id)
        {
            return _context.Options.FirstOrDefault(o=> o.Id == id);
        }

        public Option Update(Option option)
        {
            _context.Options.Update(option).CurrentValues.SetValues(option);
            _context.SaveChanges();

            return option;
        }
    }
}
