using System.Xml.Serialization;

namespace TestPlatform.Model.Squad
{    
    [XmlRoot(ElementName = "Stat")]
    public class OptaFeedSquadStat
    {
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

}
