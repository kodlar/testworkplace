using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestPlatform.Model.LiveCommentaries
{
    [XmlRoot(ElementName = "Commentary")]
    public class OptaFeedLiveCommentary
    {
        [XmlElement(ElementName = "message")]
        public List<OptaFeedLiveCommentaryMessage> Message { get; set; }
        [XmlAttribute(AttributeName = "season_id")]
        public string Season_id { get; set; }
        [XmlAttribute(AttributeName = "season")]
        public string Season { get; set; }
        [XmlAttribute(AttributeName = "matchday")]
        public string Matchday { get; set; }
        [XmlAttribute(AttributeName = "lang_id")]
        public string Lang_id { get; set; }
        [XmlAttribute(AttributeName = "home_team_name")]
        public string Home_team_name { get; set; }
        [XmlAttribute(AttributeName = "home_team_id")]
        public string Home_team_id { get; set; }
        [XmlAttribute(AttributeName = "home_score")]
        public string Home_score { get; set; }
        [XmlAttribute(AttributeName = "game_id")]
        public string Game_id { get; set; }
        [XmlAttribute(AttributeName = "game_date")]
        public string Game_date { get; set; }
        [XmlAttribute(AttributeName = "competition_id")]
        public string Competition_id { get; set; }
        [XmlAttribute(AttributeName = "competition")]
        public string Competition { get; set; }
        [XmlAttribute(AttributeName = "away_team_name")]
        public string Away_team_name { get; set; }
        [XmlAttribute(AttributeName = "away_team_id")]
        public string Away_team_id { get; set; }
        [XmlAttribute(AttributeName = "away_score")]
        public string Away_score { get; set; }
    }
}
