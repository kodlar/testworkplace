
using System.Xml.Serialization;

namespace TestPlatform.Model.Squad
{
    [XmlRoot(ElementName = "PersonName")]
    public class OptaFeedSquadPerson
    {
        [XmlElement(ElementName = "BirthDate")]
        public string BirthDate { get; set; }
        [XmlElement(ElementName = "First")]
        public string First { get; set; }
        [XmlElement(ElementName = "Last")]
        public string Last { get; set; }
        [XmlElement(ElementName = "join_date")]
        public string Join_date { get; set; }
        [XmlElement(ElementName = "leave_date")]
        public string Leave_date { get; set; }
    }
}
