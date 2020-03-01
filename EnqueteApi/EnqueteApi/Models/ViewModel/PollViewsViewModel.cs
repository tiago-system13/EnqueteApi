using System.Collections.Generic;

namespace EnqueteApi.Models.ViewModel
{
    public class PollViewsViewModel
    {
        public int Views { get; set; }

        public List<OptionViewsViewModel> Votes { get; set; }
    }
}
