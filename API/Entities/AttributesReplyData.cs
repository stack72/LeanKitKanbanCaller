using System.Collections.Generic;

namespace API.Entities
{
    public class AttributesReplyData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string Active { get; set; }
        public string OrganizationId { get; set; }
        public List<Lane> Lanes { get; set; }
    }
}