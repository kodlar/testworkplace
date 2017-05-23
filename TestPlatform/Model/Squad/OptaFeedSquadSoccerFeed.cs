using System;
using System.Xml.Serialization;

namespace TestPlatform.Model.Squad
{
    [XmlRoot(ElementName = "SoccerFeed")]
    public class OptaFeedSquadSoccerFeed
    {
        [XmlElement(ElementName = "SoccerDocument")]
        public OptaFeedSquadSoccerDocument SoccerDocument { get; set; }
        [XmlAttribute(AttributeName = "timestamp")]
        public DateTime? Timestamp { get; set; }
    }
}
