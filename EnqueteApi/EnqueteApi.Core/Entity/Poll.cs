using System.Collections.Generic;

namespace EnqueteApi.Core.Entity
{
    public class Poll
    {
        public int Id { get; set; }

        public string PollDescription { get; set; }

        public List<Option> Options { get; set; }

    }
}
