using System.Xml.Serialization;

namespace TestPlatform.Model.LiveCommentaries
{
    [XmlRoot(ElementName = "message")]
    public class OptaFeedLiveCommentaryMessage
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "comment")]
        public string Comment { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "period")]
        public string Period { get; set; }
        [XmlAttribute(AttributeName = "second")]
        public string Second { get; set; }
        [XmlAttribute(AttributeName = "minute")]
        public string Minute { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlAttribute(AttributeName = "last_modified")]
        public string Last_modified { get; set; }
    }
}
