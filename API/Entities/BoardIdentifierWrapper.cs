using System.Collections.Generic;

namespace API.Entities
{
    public class Wrapper
    {
        public string ReplyCode { get; set; }
        public string ReplyText { get; set; }
        public List<Data> ReplyData { get; set; }
        //public string ReplyData { get; set; }
    }

    public class Data
    {
        public string BoardId { get; set; }
        public List<CardType> CardTypes { get; set; }
    }

    public class CardType
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
