using System.Collections.Generic;

namespace EnqueteApi.Core.Entity
{
    public class Poll
    {
        public int Id { get; set; }

        public string PollDescription { get; set; }

        public List<Option> Options { get; set; }

        public int CountViews { get; set; }

        public Poll()
        {

        }

        public Poll(Poll poll)
        {
            Id = poll.Id;
            PollDescription = poll.PollDescription;
            Options = poll.Options;
            CountViews = poll.CountViews;
        }
    }
}
