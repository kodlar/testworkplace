
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using TestPlatform.Model.MetaPageCategory;
using TestPlatform.Model.MetaPageCategory.json;
using TestPlatform.Parser.LiveCommentaries;
using TestPlatform.Parser.Squad;

namespace TestPlatform
{
   
    class Program
    {
        static void Main(string[] args)
        {
            //LiveCommentary 
            //OptaFeedLiveCommentaryParser.Parse("http://omo.akamai.opta.net/?game_id=871651&feed_type=F13M&user=Fanatik_17&psw=aD6fjdxQVa7s");
            //Squad
            //OptaFeedSquadParser.Parse("http://omo.akamai.opta.net/competition.php?feed_type=f40&competition=115&season_id=2016&user=Fanatik_17&psw=aD6fjdxQVa7s");

            string metaPageCategory = "SELECT  [RowId],[PageId],[CategoryId],[LanguageId],[Properties] FROM [Newspaper].[dbo].[MetaPageCategory2] mc";
     
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NewspaperContext"].ConnectionString))
            {
                var metaPageCategories = connection.Query<DbEntity>(metaPageCategory).ToList();
                string pattern = File.ReadAllText(ConfigurationManager.AppSettings["pattern"]);
                string log = ConfigurationManager.AppSettings["log"];

                for (int i = 0; i < metaPageCategories.Count; i++)
                {
                    var currentItem = metaPageCategories[i];
                    
                    var jsonResponse = JsonConvert.DeserializeObject<RootObject>(currentItem.Properties);
                    
                    File.AppendAllText(log, currentItem.Properties);
                    File.AppendAllText(log, Environment.NewLine);

                    var matches = Regex.Matches(jsonResponse.Web.MetaTagsHtml, pattern, RegexOptions.Multiline);

                    for (int j = 0; j < matches.Count; j++)
                    {
                        var currentlink = matches[j].Value;

                        Console.WriteLine(currentlink);
                        File.AppendAllText(log, currentItem.RowId.ToString());
                        File.AppendAllText(log, " - ");
                        File.AppendAllText(log, currentlink);
                        File.AppendAllText(log, Environment.NewLine);

                        jsonResponse.Web.MetaTagsHtml = jsonResponse.Web.MetaTagsHtml.Replace(currentlink, "");
                        
                    }
                    
                   //update işlemi
                   var updateResult = JsonConvert.SerializeObject(jsonResponse);
                   updateResult = updateResult.Replace("'", "''");
                   string updateText = "Update [Newspaper].[dbo].[MetaPageCategory2] Set Properties = '" + updateResult + "' Where RowId = " + currentItem.RowId;
                   connection.ExecuteScalar(updateText);

                   Console.WriteLine(currentItem.RowId + " no'lu id güncellendi");
                   //Console.ReadKey();
                }
                Console.WriteLine("update işlemi tamamlandı");
                Console.ReadKey();
              
            }

        }
    }
}
