using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
namespace Tournament
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Match> matches = new List<Match>();
            matches.Add(new Match("Tournament Name", "Tournament Time", "Match Name", "Match Time"));
            matches.Add(new Match("Tournament Name", "Tournament Time", "Match Name", "Match Time"));
            matches.Add(new Match("Tournament Name", "Tournament Time", "Match Name", "Match Time"));
            matches.Add(new Match("Tournament Name", "Tournament Time", "Match Name", "Match Time"));
            DataTable table = new DataTable();

            table.Columns.Add("Tournament Name", typeof(string));
            table.Columns.Add("Tournament Time", typeof(string));
            table.Columns.Add("Match Name", typeof(string));
            table.Columns.Add("Match Time", typeof(string));
            for (int i = 0; i < matches.Count; i++)
            {
                table.Rows.Add(matches[i].TournamentName, matches[i].TournamenTime, matches[i].MatchName, matches[i].MatchTime);
            }
            dataGridView1.DataSource = table;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Players newForm = new Players();
            newForm.Show();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            FansForm newForm = new FansForm();
            newForm.Show();
        }
    }
}
