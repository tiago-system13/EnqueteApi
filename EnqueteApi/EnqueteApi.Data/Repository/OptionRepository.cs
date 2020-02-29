using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Data.Context;

namespace EnqueteApi.Data.Repository
{
    public class OptionRepository : IOptionsRepository
    {
        private readonly EnqueteApiContext _context;

        public OptionRepository(EnqueteApiContext context)
        {
            _context = context;
        }

        public void Update(Option option)
        {
            _context.Options.Update(option).CurrentValues.SetValues(option);
            _context.SaveChanges();
        }
    }
}
