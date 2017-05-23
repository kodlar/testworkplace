using System.Xml.Serialization;

namespace TestPlatform.Model.Squad
{
    [XmlRoot(ElementName = "Stadium")]
    public class OptaFeedSquadStadium
    {
        [XmlElement(ElementName = "Capacity")]
        public string Capacity { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "uID")]
        public string UID { get; set; }
    }
}
