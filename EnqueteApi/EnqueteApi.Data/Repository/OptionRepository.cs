using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Data.Context;
using Microsoft.EntityFrameworkCore;
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
            return _context.Options.AsNoTracking().FirstOrDefault(o=> o.Id == id);
        }

        public Option Update(Option option, Option optinOld)
        {         
            _context.Options.Update(optinOld).CurrentValues.SetValues(option);
            _context.SaveChanges();

            return option;
        }
    }
}
