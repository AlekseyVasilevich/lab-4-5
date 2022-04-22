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
        public Match(string tournamentName, string tournamentTime, string matchName, string matchTime) : base(tournamentName, tournamentTime)
        {
            MatchName = matchName;
            MatchTime = matchTime;
        }
        public Match(string matchName, string matchTime)
        {
            MatchName = matchName;
            MatchTime = matchTime;
        }
        public override sealed void DisplayInfo()
        {
            //      Console.WriteLine($"{TournamentName} {TournamenTime} {MatchName} {MatchTime}");
        }
    }
}
