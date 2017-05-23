using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestPlatform.Model.Squad
{
    [XmlRoot(ElementName = "SoccerDocument")]
    public class OptaFeedSquadSoccerDocument
    {
        [XmlElement(ElementName = "Team")]
        public List<OptaFeedSquadTeam> Team { get; set; }
        [XmlElement(ElementName = "PlayerChanges")]
        public OptaFeedSquadPlayerChanges PlayerChanges { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "competition_code")]
        public string Competition_code { get; set; }
        [XmlAttribute(AttributeName = "competition_id")]
        public string Competition_id { get; set; }
        [XmlAttribute(AttributeName = "competition_name")]
        public string Competition_name { get; set; }
        [XmlAttribute(AttributeName = "season_id")]
        public string Season_id { get; set; }
        [XmlAttribute(AttributeName = "season_name")]
        public string Season_name { get; set; }
    }
}
