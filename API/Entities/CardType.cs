namespace API.Entities
{
    public class CardType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ColorHex { get; set; }
        public string IsDefault { get; set; }
        public string IconPath { get; set; } 

        public override string ToString()
        {
            return Name;
        }
    }
}