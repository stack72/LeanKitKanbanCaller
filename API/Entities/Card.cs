namespace API.Entities
{
    public class Card
    {
        public string SystemType { get; set; }
        public string Id { get; set; }
        public string LaneId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }
        public string TypeId { get; set; }
        public string Priority { get; set; }
        public string PriorityText { get; set; }

    }

    public class Type
    {
        public string Id { get; set; }
    }
}