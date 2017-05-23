using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestPlatform.Model.Squad
{
    [XmlRoot(ElementName = "PlayerChanges")]
    public class OptaFeedSquadPlayerChanges
    {
        [XmlElement(ElementName = "Team")]
        public List<OptaFeedSquadTeam> Team { get; set; }
    }
}
