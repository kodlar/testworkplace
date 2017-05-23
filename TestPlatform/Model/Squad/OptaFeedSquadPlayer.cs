using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestPlatform.Model.Squad
{
    [XmlRoot(ElementName = "Player")]
    public class OptaFeedSquadPlayer
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Position")]
        public string Position { get; set; }
        [XmlElement(ElementName = "Stat")]
        public List<OptaFeedSquadStat> Stat { get; set; }
        [XmlAttribute(AttributeName = "uID")]
        public string UID { get; set; }
        [XmlAttribute(AttributeName = "loan")]
        public string Loan { get; set; }
    }
}
