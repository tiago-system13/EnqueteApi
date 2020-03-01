namespace EnqueteApi.Core.Entity
{
    public class Option
    {
        public int Id { get; set; }

        public int PollId { get; set; }

        public string OptionDescription { get; set; }

        public int? Count { get; set; }

        public Poll Poll { get; set; }

        public Option()
        {

        }

        public Option(Option option)
        {
            Id = option.Id;
            PollId = option.PollId;
            OptionDescription = option.OptionDescription;
            Count = option.Count;
        }
    }
}
