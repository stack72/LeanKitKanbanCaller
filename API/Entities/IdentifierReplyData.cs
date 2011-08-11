using System.Collections.Generic;

namespace API.Entities
{
    public class IdentifierReplyData
    {
        public string BoardId { get; set; }
        public List<CardType> CardTypes { get; set; }
        public List<BoardUser> BoardUsers { get; set; }
        public List<Lane> Lanes { get; set; }
        public List<Priority> Priorities { get; set; }
    }
}