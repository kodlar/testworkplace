using System;
using System.Collections.Generic;
using System.Xml;
using TestPlatform.Helper;
using TestPlatform.Model.Squad;

namespace TestPlatform.Parser.Squad
{
    public class OptaFeedSquadParser
    {
        public static void Parse(string url)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(url);

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/SoccerFeed");

                if (nodes.Count > 0)
                {
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        var soccerFeedNode = nodes[i];
                        //Feed Tarihini alalım
                        OptaFeedSquadSoccerFeed soccerFeed = new OptaFeedSquadSoccerFeed();

                        if (soccerFeedNode.Attributes.Count > 0)
                        {
                            for (int j = 0; j < soccerFeedNode.Attributes.Count; j++)
                            {
                                var currentSoccerFeedNodeAttribute = soccerFeedNode.Attributes[j];
                                DateTime? feedDateTime = Util.UnixTimeStampToDateTime(currentSoccerFeedNodeAttribute.Value);
                                soccerFeed.Timestamp = feedDateTime;
                            }
                        }

                        if (soccerFeedNode.ChildNodes.Count > 0)
                        {

                            for (int x = 0; x < soccerFeedNode.ChildNodes.Count; x++)
                            {
                                var currentSoccerFeedElement = soccerFeedNode.ChildNodes[x];
                                var soccerDocument = new OptaFeedSquadSoccerDocument();

                                if (currentSoccerFeedElement.Attributes.Count > 0)
                                {
                                    for (int k = 0; k < currentSoccerFeedElement.Attributes.Count; k++)
                                    {
                                        //turnuva ve sezon bilgileri
                                        var currentSoccerDocumentElementAttribute = currentSoccerFeedElement.Attributes[k];
                                        switch (currentSoccerDocumentElementAttribute.Name)
                                        {
                                            case "Type":
                                                soccerDocument.Type = currentSoccerDocumentElementAttribute.Value;
                                                break;
                                            case "competition_code":
                                                soccerDocument.Competition_code = currentSoccerDocumentElementAttribute.Value;
                                                break;
                                            case "competition_id":
                                                soccerDocument.Competition_id = currentSoccerDocumentElementAttribute.Value;
                                                break;
                                            case "competition_name":
                                                soccerDocument.Competition_name = currentSoccerDocumentElementAttribute.Value;
                                                break;
                                            case "season_id":
                                                soccerDocument.Season_id = currentSoccerDocumentElementAttribute.Value;
                                                break;
                                            case "season_name":
                                                soccerDocument.Season_name = currentSoccerDocumentElementAttribute.Value;
                                                break;
                                        }
                                    }

                                    //takım ülke bilgisi
                                    if (currentSoccerFeedElement.ChildNodes.Count > 0)
                                    {
                                        var teams = new List<OptaFeedSquadTeam>();

                                        for (int t = 0; t < currentSoccerFeedElement.ChildNodes.Count; t++)
                                        {
                                            OptaFeedSquadTeam team = new OptaFeedSquadTeam();
                                            var currentNode = currentSoccerFeedElement.ChildNodes[t];

                                            if (currentNode.Attributes.Count > 0)
                                            {
                                                for (int te = 0; te < currentNode.Attributes.Count; te++)
                                                {
                                                    var currentTeamAttributes = currentNode.Attributes[te];

                                                    switch (currentTeamAttributes.Name)
                                                    {
                                                        case "country":
                                                            team.Country = currentTeamAttributes.Value;
                                                            break;
                                                        case "country_id":
                                                            team.Country_id = currentTeamAttributes.Value;
                                                            break;
                                                        case "country_iso":
                                                            team.Country_iso = currentTeamAttributes.Value;
                                                            break;
                                                        case "region_id":
                                                            team.Region_id = currentTeamAttributes.Value;
                                                            break;
                                                        case "region_name":
                                                            team.Region_name = currentTeamAttributes.Value;
                                                            break;
                                                        case "uID":
                                                            team.UID = currentTeamAttributes.Value;
                                                            break;
                                                        case "short_club_name":
                                                            team.Short_club_name = currentTeamAttributes.Value;
                                                            break;
                                                    }

                                                }

                                                teams.Add(team);

                                            }
                                            else
                                            {
                                                var optaFeedSquadPlayerChanges = new OptaFeedSquadPlayerChanges();

                                                if (currentNode.HasChildNodes)
                                                {
                                                    //oyuncu ve teknik direktör transferleri
                                                   
                                                    var teamSquadList = new List<OptaFeedSquadTeam>();
                                                   
                                                    for (int g = 0; g < currentNode.ChildNodes.Count; g++)
                                                    {
                                                        var playerChangesNode = currentNode.ChildNodes[g];

                                                        var playerList = new List<OptaFeedSquadPlayer>();
                                                        var teamOfficialList = new List<OptaFeedSquadTeamOfficial>();

                                                        var teamSquad = new OptaFeedSquadTeam();

                                                        if (playerChangesNode.Attributes != null && playerChangesNode.Attributes.Count > 0)
                                                        {
                                                           teamSquad.UID = playerChangesNode.Attributes[0].Value;
                                                        }

                                                        
                                                        if (playerChangesNode.HasChildNodes)
                                                        {
                                                           
                                                            for (int w = 0; w < playerChangesNode.ChildNodes.Count; w++)
                                                            {
                                                                
                                                                var playerNode = playerChangesNode.ChildNodes[w];

                                                                switch (playerNode.Name)
                                                                {
                                                                    case "Name":
                                                                        teamSquad.Name = playerNode.InnerText;
                                                                        break;
                                                                    case "Player":
                                                                        playerList.Add(Player(playerNode));
                                                                        break;
                                                                    case "TeamOfficial":
                                                                        teamOfficialList.Add(TeamOfficial(playerNode));
                                                                        break;
                                                                }
                                                                teamSquad.Player = playerList;
                                                                teamSquad.TeamOfficial = teamOfficialList;
                                                            }
                                                            teamSquadList.Add(teamSquad);
                                                        }
                                                        
                                                       
                                                    }
                                                    optaFeedSquadPlayerChanges.Team = teamSquadList;
                                                   
                                                }


                                                soccerDocument.PlayerChanges = optaFeedSquadPlayerChanges;

                                            }
                                            
                                            if (currentNode.HasChildNodes)
                                            {
                                                var squadPlayerList = new List<OptaFeedSquadPlayer>();
                                                for (int r = 0; r < currentNode.ChildNodes.Count; r++)
                                                {
                                                    var teamElementName = currentNode.ChildNodes[r];
                                                    switch (teamElementName.Name)
                                                    {
                                                        case "Founded":
                                                            team.Founded = teamElementName.InnerText;
                                                            break;
                                                        case "Name":
                                                            team.Name = teamElementName.InnerText;
                                                            break;
                                                        case "Player":
                                                            squadPlayerList.Add(Player(teamElementName));
                                                            break;
                                                        case "SYMID":
                                                            team.SYMID = teamElementName.InnerText;
                                                            break;
                                                        case "Stadium":
                                                            team.Stadium = Stadium(teamElementName);
                                                            break;
                                                        case "TeamOfficial":
                                                            team.TeamOfficial = TeamOfficialList(teamElementName);
                                                            break;
                                                    }
                                                                                                    
                                                   
                                                }

                                                team.Player = squadPlayerList;
                                            }





                                        }

                                        soccerDocument.Team = teams;
                                    }

                                    soccerFeed.SoccerDocument = soccerDocument;
                                }
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

        //Stadyum bilgisi
        private static OptaFeedSquadStadium Stadium(XmlNode node)
        {
            OptaFeedSquadStadium stadium = new OptaFeedSquadStadium();

            if (node.Attributes.Count > 0)
            {
                for (int i = 0; i < node.Attributes.Count; i++)
                {
                    var nodeAttribute = node.Attributes[i];
                    stadium.UID = nodeAttribute.Value;
                }
            }

            if (node.HasChildNodes)
            {
                for (int j = 0; j < node.ChildNodes.Count; j++)
                {
                    var nodeChildNode = node.ChildNodes[j];
                    switch (nodeChildNode.Name)
                    {
                        case "Capacity":
                            stadium.Capacity = nodeChildNode.InnerText;
                            break;
                        case "Name":
                            stadium.Name = nodeChildNode.InnerText;
                            break;
                    }
                }
            }

            return stadium;
        }
        //Teknik direktör bilgisi
        private static List<OptaFeedSquadTeamOfficial> TeamOfficialList(XmlNode node)
        {
            List<OptaFeedSquadTeamOfficial> lst = new List<OptaFeedSquadTeamOfficial>();
            var teamOfficial = new OptaFeedSquadTeamOfficial();

            if (node.Attributes.Count > 0)
            {
                for (int i = 0; i < node.Attributes.Count; i++)
                {
                    var nodeAttribute = node.Attributes[i];
                    switch (nodeAttribute.Name)
                    {
                        case "Type":
                            teamOfficial.Type = nodeAttribute.Value;
                            break;
                        case "country":
                            teamOfficial.Country = nodeAttribute.Value;
                            break;
                        case "uID":
                            teamOfficial.UID = nodeAttribute.Value;
                            break;
                    }
                }
            }

            if (node.HasChildNodes)
            {
                var person = new OptaFeedSquadPerson();
                for (int j = 0; j < node.ChildNodes.Count; j++)
                {
                    var nodeChildNode = node.ChildNodes[j];

                    if (nodeChildNode.HasChildNodes)
                    {
                        for (int z = 0; z < nodeChildNode.ChildNodes.Count; z++)
                        {
                            var subChildNode = nodeChildNode.ChildNodes[z];

                            switch (subChildNode.Name)
                            {
                                case "BirthDate":
                                    person.BirthDate = subChildNode.InnerText;
                                    break;
                                case "First":
                                    person.First = subChildNode.InnerText;
                                    break;
                                case "Last":
                                    person.Last = subChildNode.InnerText;
                                    break;
                                case "join_date":
                                    person.Join_date = subChildNode.InnerText;
                                    break;
                                case "leave_date":
                                    person.Leave_date = subChildNode.InnerText;
                                    break;
                            }
                        }
                    }

                }

                teamOfficial.PersonName = person;
            }

            lst.Add(teamOfficial);

            return lst;
        }


        private static OptaFeedSquadTeamOfficial TeamOfficial(XmlNode node)
        {
            
            var teamOfficial = new OptaFeedSquadTeamOfficial();

            if (node.Attributes.Count > 0)
            {
                for (int i = 0; i < node.Attributes.Count; i++)
                {
                    var nodeAttribute = node.Attributes[i];
                    switch (nodeAttribute.Name)
                    {
                        case "Type":
                            teamOfficial.Type = nodeAttribute.Value;
                            break;
                        case "country":
                            teamOfficial.Country = nodeAttribute.Value;
                            break;
                        case "uID":
                            teamOfficial.UID = nodeAttribute.Value;
                            break;
                    }
                }
            }

            if (node.HasChildNodes)
            {
                var person = new OptaFeedSquadPerson();
                for (int j = 0; j < node.ChildNodes.Count; j++)
                {
                    var nodeChildNode = node.ChildNodes[j];

                    if (nodeChildNode.HasChildNodes)
                    {
                        for (int z = 0; z < nodeChildNode.ChildNodes.Count; z++)
                        {
                            var subChildNode = nodeChildNode.ChildNodes[z];

                            switch (subChildNode.Name)
                            {
                                case "BirthDate":
                                    person.BirthDate = subChildNode.InnerText;
                                    break;
                                case "First":
                                    person.First = subChildNode.InnerText;
                                    break;
                                case "Last":
                                    person.Last = subChildNode.InnerText;
                                    break;
                                case "join_date":
                                    person.Join_date = subChildNode.InnerText;
                                    break;
                                case "leave_date":
                                    person.Leave_date = subChildNode.InnerText;
                                    break;
                            }
                        }
                    }

                }

                teamOfficial.PersonName = person;
            }

           
            return teamOfficial;
        }

        //Oyuncu bilgisi
        private static OptaFeedSquadPlayer Player(XmlNode node)
        {
           
            var player = new OptaFeedSquadPlayer();

            var statList = new List<OptaFeedSquadStat>();
           
            if (node.Attributes.Count > 0)
            {
                for (int i = 0; i < node.Attributes.Count; i++)
                {
                    var nodeAttribute = node.Attributes[i];
                    switch (nodeAttribute.Name)
                    {
                        case "uID":
                            player.UID = nodeAttribute.Value;
                            break;
                        case "country":
                            player.Loan = nodeAttribute.Value;
                            break;
                    }
                }
            }

            if (node.HasChildNodes)
            {
                for (int j = 0; j < node.ChildNodes.Count; j++)
                {
                    var nodeChildNode = node.ChildNodes[j];
                    
                    switch (nodeChildNode.Name)
                    {
                        case "Name":
                            player.Name = nodeChildNode.InnerText;
                            break;
                        case "Position":
                            player.Position = nodeChildNode.InnerText;
                            break;                        
                    }

                    if (nodeChildNode.Name.Equals("Stat"))
                    {
                      var stat = new OptaFeedSquadStat();
                      stat.Type = nodeChildNode.Attributes[0].Value;
                      stat.Text = nodeChildNode.InnerText;
                      statList.Add(stat);
                    }

                    
                }

                player.Stat = statList;
            }

          

            return player;
        }


    }
}
