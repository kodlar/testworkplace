using System;
using System.Collections.Generic;
using System.Xml;
using TestPlatform.Model.LiveCommentaries;

namespace TestPlatform.Parser.LiveCommentaries
{
    public static class OptaFeedLiveCommentaryParser
    {
        public static void Parse(string url)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(url);

                XmlNodeList commentaryNodes = doc.DocumentElement.SelectNodes("/Commentary");

                if (commentaryNodes.Count > 0)
                {
                    for (int i = 0; i < commentaryNodes.Count; i++)
                    {
                        var currentNode = commentaryNodes[i];

                        if (currentNode.Attributes.Count > 0)
                        {
                            OptaFeedLiveCommentary commentary = new OptaFeedLiveCommentary();

                            for (int j = 0; j < currentNode.Attributes.Count; j++)
                            {
                                var currentCommentaryNode = currentNode.Attributes[j];
                                switch (currentCommentaryNode.Name)
                                {
                                    case "season_id":
                                        commentary.Season_id = currentCommentaryNode.Value;
                                        break;
                                    case "season":
                                        commentary.Season = currentCommentaryNode.Value;
                                        break;
                                    case "matchday":
                                        commentary.Matchday = currentCommentaryNode.Value;
                                        break;
                                    case "lang_id":
                                        commentary.Lang_id = currentCommentaryNode.Value;
                                        break;
                                    case "home_team_name":
                                        commentary.Home_team_name = currentCommentaryNode.Value;
                                        break;
                                    case "home_team_id":
                                        commentary.Home_team_id = currentCommentaryNode.Value;
                                        break;
                                    case "home_score":
                                        commentary.Home_score = currentCommentaryNode.Value;
                                        break;
                                    case "game_id":
                                        commentary.Game_id = currentCommentaryNode.Value;
                                        break;
                                    case "game_date":
                                        commentary.Game_date = currentCommentaryNode.Value;
                                        break;
                                    case "competition_id":
                                        commentary.Competition_id = currentCommentaryNode.Value;
                                        break;
                                    case "competition":
                                        commentary.Competition = currentCommentaryNode.Value;
                                        break;
                                    case "away_team_name":
                                        commentary.Away_team_name = currentCommentaryNode.Value;
                                        break;
                                    case "away_team_id":
                                        commentary.Away_team_id = currentCommentaryNode.Value;
                                        break;
                                    case "away_score":
                                        commentary.Away_score = currentCommentaryNode.Value;
                                        break;

                                }
                                
                            }

                            if (currentNode.ChildNodes.Count > 0)
                            {
                                List<OptaFeedLiveCommentaryMessage> messages = new List<OptaFeedLiveCommentaryMessage>();

                                for (int k = 0; k < currentNode.ChildNodes.Count; k++)
                                {
                                    var currentMessageNode = currentNode.ChildNodes[k];
                                    OptaFeedLiveCommentaryMessage message = new OptaFeedLiveCommentaryMessage();
                                    for (int z = 0; z < currentMessageNode.Attributes.Count; z++)
                                    {
                                        var currentMessage = currentMessageNode.Attributes[z];
                                       
                                        switch (currentMessage.Name)
                                        {
                                            case "id":
                                                message.Id = currentMessage.Value;
                                                break;
                                            case "comment":
                                                message.Comment = currentMessage.Value;
                                                break;
                                            case "type":
                                                message.Type = currentMessage.Value;
                                                break;
                                            case "period":
                                                message.Period = currentMessage.Value;
                                                break;
                                            case "second":
                                                message.Second = currentMessage.Value;
                                                break;
                                            case "minute":
                                                message.Minute = currentMessage.Value;
                                                break;
                                            case "time":
                                                message.Time = currentMessage.Value;
                                                break;
                                            case "last_modified":
                                                message.Last_modified = currentMessage.Value;
                                                break;
                                        }
                                       
                                    }
                                    messages.Add(message);

                                }

                                commentary.Message = messages;
                            }

                            
                        }



                    }


                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }

            
        }
    }
}
