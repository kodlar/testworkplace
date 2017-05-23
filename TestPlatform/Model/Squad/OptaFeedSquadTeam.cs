using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestPlatform.Model.Squad
{
    [XmlRoot(ElementName = "Team")]
    public class OptaFeedSquadTeam
    {
        [XmlElement(ElementName = "Founded")]
        public string Founded { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Player")]
        public List<OptaFeedSquadPlayer> Player { get; set; }
        [XmlElement(ElementName = "SYMID")]
        public string SYMID { get; set; }
        [XmlElement(ElementName = "Stadium")]
        public OptaFeedSquadStadium Stadium { get; set; }
        [XmlElement(ElementName = "TeamOfficial")]
        public List<OptaFeedSquadTeamOfficial> TeamOfficial { get; set; }
        [XmlAttribute(AttributeName = "country")]
        public string Country { get; set; }
        [XmlAttribute(AttributeName = "country_id")]
        public string Country_id { get; set; }
        [XmlAttribute(AttributeName = "country_iso")]
        public string Country_iso { get; set; }
        [XmlAttribute(AttributeName = "region_id")]
        public string Region_id { get; set; }
        [XmlAttribute(AttributeName = "region_name")]
        public string Region_name { get; set; }
        [XmlAttribute(AttributeName = "uID")]
        public string UID { get; set; }
        [XmlAttribute(AttributeName = "short_club_name")]
        public string Short_club_name { get; set; }
    }
}
