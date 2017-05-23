using System.Xml.Serialization;

namespace TestPlatform.Model.Squad
{
    [XmlRoot(ElementName = "TeamOfficial")]
    public class OptaFeedSquadTeamOfficial
    {
        [XmlElement(ElementName = "PersonName")]
        public OptaFeedSquadPerson PersonName { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "country")]
        public string Country { get; set; }
        [XmlAttribute(AttributeName = "uID")]
        public string UID { get; set; }
    }
}
