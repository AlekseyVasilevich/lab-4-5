using System;
using System.Data;

namespace Tournament
{
    class Fans : Person
    {
        public string FavoriteCommand { get; set; }
        public string FavoritePlayer { get; set; }
        public Fans(string personName, string personSurname, string favoriteCommand, string favoritePlayer) : base(personName, personSurname)
        {
            FavoriteCommand = favoriteCommand;
            FavoritePlayer = favoritePlayer;
        }
        public Fans(string favoriteCommand, string favoritePlayer)
        {
            FavoriteCommand = favoriteCommand;
            FavoritePlayer = favoritePlayer;
        }
        public Fans()
        {
            FavoriteCommand = "defaultTeam";
            FavoritePlayer = "firstplayer";
        }
        public override DataTable DisplayInfo()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Surname", typeof(string));
            table.Columns.Add("Favorite command", typeof(string));
            table.Columns.Add("Favorite player", typeof(string));
            table.Rows.Add(PersonName, PersonSurname, FavoriteCommand, FavoritePlayer);
            return table;
        }
    }
}
