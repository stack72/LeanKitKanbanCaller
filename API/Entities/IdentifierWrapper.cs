using System.Collections.Generic;

namespace API.Entities
{
    public class IdentifierWrapper
    {
        public string ReplyCode { get; set; }
        public string ReplyText { get; set; }
        public List<IdentifierReplyData> ReplyData { get; set; }
    }
}
