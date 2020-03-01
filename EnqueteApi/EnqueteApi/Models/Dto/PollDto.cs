using System.Collections.Generic;

namespace EnqueteApi.Models.Dto
{
    public class PollDto
    {
        public string PollDescription { get; set; }

        public List<OptionDto> Options { get; set; }
    }
}
