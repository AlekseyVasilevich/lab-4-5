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
using System.Linq;

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
            matches.Add(new Match("Tournament Name", "Tournament Time", "Match Name", "Match Time", 1200));
            matches.Add(new Match("Tournament Name", "Tournament Time", "Match Name", "Match Time", 1000));
            matches.Add(new Match("Tournament Name", "Tournament Time", "Match Name", "Match Time", 3000));
            matches.Add(new Match("Tournament Name", "Tournament Time", "Match Name", "Match Time", 2500));
            DataTable table = new DataTable();

            table.Columns.Add("Tournament Name", typeof(string));
            table.Columns.Add("Tournament Time", typeof(string));
            table.Columns.Add("Match Name", typeof(string));
            table.Columns.Add("Match Time", typeof(string));
            table.Columns.Add("Count Fans", typeof(int));
            for (int i = 0; i < matches.Count; i++)
            {
                table.Rows.Add(matches[i].TournamentName, matches[i].TournamenTime, matches[i].MatchName, matches[i].MatchTime, matches[i].CountFans);
            }
            dataGridView1.DataSource = table;

            int minFans = matches.Min(p => p.CountFans);
            int maxFans = matches.Max(p => p.CountFans);
            double averageFans = matches.Average(p => p.CountFans);
            int totalMatches = matches.Count();
            richTextBox1.AppendText($"Min Fans - {minFans}\nMax fans - {maxFans}\nAverage fans - {averageFans}\nTotal matches - {totalMatches}");
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
