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
        public List<BoardUser> BoardUsers { get; set; }
        public List<Lane> Backlog { get; set; }
        public List<Lane> Archive { get; set; }
        public string ClassOfServiceEnabled { get; set; }
        public List<ClassOfService> ClassesOfService { get; set; }
        public string CardColorField { get; set; }
        public string IsCardIdEnabled { get; set; }
        public string IsHeaderEnabled { get; set; }
        public string IsPrefixEnabled { get; set; }
        public string IsPrefixIncludedInHyperlink { get; set; }
        public string Prefix { get; set; }
        public string IsHyperlinkEnabled { get; set; }
        public string Format { get; set; }
        public string AllowMultiUserAssignments { get; set; }
        public string BaseWipOnCardSize { get; set; }
        public string ExcludeFromOrgAnalytics { get; set; }
        public string ExcludeCompletedAndArchiveViolations { get; set; }
        public List<int> TopLevelLaneIds { get; set; }
        public string BacklogTopLevelLaneId { get; set; }
        public string ArchiveTopLevelLaneId { get; set; }
        public string CurrentUserRole { get; set; }
        public List<CardType> CardTypes { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}