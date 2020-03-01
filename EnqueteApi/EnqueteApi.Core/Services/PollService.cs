using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnqueteApi.Core.Services
{
    public class PollService : IPollService
    {
        private readonly IPollRepository _pollRepository;

        public PollService(IPollRepository pollRepository)
        {
            _pollRepository = pollRepository;
        }

        public int Add(Poll poll)
        {
            if (poll.Options != null)
            {
                foreach (var option in poll.Options)
                {
                    option.Poll = poll;
                }
            }

            return _pollRepository.Add(poll);            
        }

        public Poll GetbyId(int id)
        {
            var poll = _pollRepository.GetbyId(id);

            if (poll == null)
            {
                throw new ArgumentException("Enquete não encontrada!");
            }

            return poll;
        }
    }
}
