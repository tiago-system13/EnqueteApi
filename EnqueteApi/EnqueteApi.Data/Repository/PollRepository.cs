using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnqueteApi.Data.Repository
{
    public class PollRepository : IPollRepository
    {
        private readonly EnqueteApiContext _context;

        public PollRepository(EnqueteApiContext context)
        {
            _context = context;
        }

        public int Add(Poll poll)
        {
            _context.Polls.Add(poll);
            _context.SaveChanges();
            return poll.Id;            
        }

        public Poll GetbyId(int id)
        {
            return _context.Polls.AsNoTracking().Include(p => p.Options).FirstOrDefault(p=> p.Id == id);
        }

        public Poll Update(Poll poll, Poll pollOld)
        {
            _context.Polls.Update(pollOld).CurrentValues.SetValues(poll);
            _context.SaveChanges();

            return poll;
        }
    }
}
