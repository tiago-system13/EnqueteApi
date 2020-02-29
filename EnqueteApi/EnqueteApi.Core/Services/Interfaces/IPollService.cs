using EnqueteApi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnqueteApi.Core.Services.Interfaces
{
    public interface IPollService
    {
        Poll GetbyId(int id);

        int Add(Poll poll);
    }
}
