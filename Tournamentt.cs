using System.IO;

namespace Tournament
{
    class Tournament
    {

        /*public string TournamentName
        {
            get { return tournamentName; }
            set { tournamentName = value; }
        }*/
        public string TournamentName { get; set; }
        public string TournamenTime { get; set; }
        public Tournament(string tournamentName, string tournamentTime)
        {
            TournamentName = tournamentName;
            TournamenTime = tournamentTime;
        }
        public Tournament()
        {
            TournamentName = "firsttournament";
            TournamenTime = "20:00 01.10.2020";
        }
        public virtual void DisplayInfo()
        {

        }
        public void printInfoInFile()
        {
            FileStream fs = new FileStream("info.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(TournamentName + " " + TournamenTime);
            sw.Close();
        }
    }
}
