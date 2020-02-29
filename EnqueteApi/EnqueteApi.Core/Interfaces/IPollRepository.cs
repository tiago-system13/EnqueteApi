using EnqueteApi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnqueteApi.Core.Interfaces
{
   public interface IPollRepository
    {
        Poll GetbyId(int id);

        int Add(Poll poll);
    }
}
