using System;
using System.Data;
using System.Linq;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;

namespace Tournament
{
    public partial class Players : MaterialForm
    {
        public Players()
        {
            InitializeComponent();
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
                );
        }

        private void Players_Load(object sender, EventArgs e)
        {
            using (ApplicationContext2 db = new ApplicationContext2())
            {           
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Team dynamo = new Team { Name = "Dynamo" };
                Team manchester = new Team { Name = "Manchester" };
                db.Teams.AddRange(dynamo, manchester);

                Player tom = new Player { Name = "Tom", Surname="Edison", Role="goalkeeper", Team = dynamo };
                Player bob = new Player { Name = "Bob", Surname = "Tomas", Role = "attack", Team = dynamo };
                Player alice = new Player { Name = "Antony", Surname = "Gregos", Role = "attack", Team = manchester };
                db.Players.AddRange(tom, bob, alice);
                db.SaveChanges();
            }
            DataTable table = new DataTable();
            table.Columns.Add("Team name", typeof(string));
            table.Columns.Add("Player name", typeof(string));
            table.Columns.Add("Player surname", typeof(string));
            table.Columns.Add("Player role", typeof(string));
            using (ApplicationContext2 db = new ApplicationContext2())
            {
                var players = db.Players.Include(u => u.Team).ToList();
                foreach (Player player in players)
                {
                    table.Rows.Add(player.Name, player.Surname, player.Role, player.Team?.Name);
                }
                dataGridView1.DataSource = table;
                var teams = db.Teams.Include(c => c.Players).ToList();
                foreach (Team team in teams)
                {
                    richTextBox1.AppendText($"Команда: {team.Name}\n");
                   
                    foreach (Player player in team.Players)
                    {
                        richTextBox1.AppendText($"{player.Name} {player.Surname} {player.Role}\n");
                       
                    }
                }
            }
        }
    }
}
