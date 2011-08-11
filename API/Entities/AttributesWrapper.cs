using System.Collections.Generic;

namespace API.Entities
{
    public class AttributesWrapper
    {
        public string ReplyCode { get; set; }
        public string ReplyText { get; set; }
        public List<AttributesReplyData> ReplyData { get; set; }
    }
}