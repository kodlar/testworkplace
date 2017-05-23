
using TestPlatform.Parser.LiveCommentaries;
using TestPlatform.Parser.Squad;

namespace TestPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            //LiveCommentary 
           OptaFeedLiveCommentaryParser.Parse("http://omo.akamai.opta.net/?game_id=871651&feed_type=F13M&user=Fanatik_17&psw=aD6fjdxQVa7s");
            //Squad
           OptaFeedSquadParser.Parse("http://omo.akamai.opta.net/competition.php?feed_type=f40&competition=115&season_id=2016&user=Fanatik_17&psw=aD6fjdxQVa7s");
        }
    }
}
