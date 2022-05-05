using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament
{
    class Match : Tournament
    {
        public string MatchName { get; set; }
        public string MatchTime { get; set; }
        public int CountFans { get; set; }
        public Match(string tournamentName, string tournamentTime, string matchName, string matchTime, int countFans) : base(tournamentName, tournamentTime)
        {
            MatchName = matchName;
            MatchTime = matchTime;
            CountFans = countFans;
        }
        public Match(string matchName, string matchTime, int countFans)
        {
            MatchName = matchName;
            MatchTime = matchTime;
            CountFans = countFans;
        }
        public override sealed void DisplayInfo()
        {
            //      Console.WriteLine($"{TournamentName} {TournamenTime} {MatchName} {MatchTime}");
        }
    }
}
