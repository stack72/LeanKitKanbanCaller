namespace API.Entities
{
    public class BoardUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string WIP { get; set; }
        public string Enabled { get; set; }
        public string IsAccountOwner { get; set; }
        public string IsDeleted { get; set; }
        public string GravatarFeed { get; set; }
        public string EmailAddress { get; set; }
        public string DateFormat { get; set; }
        public string GravatarLink { get; set; }
        public string Settings { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
