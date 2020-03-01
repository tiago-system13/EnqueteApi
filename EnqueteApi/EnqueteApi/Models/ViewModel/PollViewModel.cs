using System.Collections.Generic;

namespace EnqueteApi.Models.ViewModel
{
    public class PollViewModel
    {
        public int Id { get; set; }

        public string PollDescription { get; set; }

        public List<OptionViewModel> Options { get; set; }
    }
}
