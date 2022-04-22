using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Tournament
{
    public partial class FansForm : MaterialForm
    {
        public FansForm()
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

        private void FansForm_Load(object sender, EventArgs e)
        {
            // adding
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Ticket Ticket1 = new Ticket { FanName = "Tom", FavoriteCommand="Dynamo", TicketNumber = 331 };
                Ticket Ticket2 = new Ticket { FanName = "Bob", FavoriteCommand="Manchester", TicketNumber = 112 };
                Ticket Ticket3 = new Ticket { FanName = "John", FavoriteCommand = "Manchester", TicketNumber = 312 };
                // add
                db.Tickets.Add(Ticket1);
                db.Tickets.Add(Ticket2);
                db.Tickets.Add(Ticket3);
                db.SaveChanges();
            }
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Fan name", typeof(string));
            table.Columns.Add("Favorite command", typeof(string));
            table.Columns.Add("Ticket Number", typeof(int));

            // receiving and display info
            using (ApplicationContext db = new ApplicationContext())
            {
                var tickets = db.Tickets.ToList();
                foreach (Ticket t in tickets)
                {
                    table.Rows.Add(t.Id, t.FanName, t.FavoriteCommand, t.TicketNumber);
                }

            }
            dataGridView1.DataSource = table;

            DataTable table1 = new DataTable();
            table1.Columns.Add("Id", typeof(int));
            table1.Columns.Add("Fan name", typeof(string));
            table1.Columns.Add("Favorite command", typeof(string));
            table1.Columns.Add("Ticket Number", typeof(int));
            // edit
            using (ApplicationContext db = new ApplicationContext())
            {
                Ticket ticket = db.Tickets.FirstOrDefault();
                if (ticket != null)
                {
                    ticket.FanName = "Antony";
                    ticket.TicketNumber = 444;
                    db.SaveChanges();
                }
                var tickets = db.Tickets.ToList();
                //display
                foreach (Ticket t in tickets)
                {
                    table1.Rows.Add(t.Id, t.FanName, t.FavoriteCommand, t.TicketNumber);
                }
            }
            dataGridView2.DataSource = table1;

            DataTable table2 = new DataTable();
            table2.Columns.Add("Id", typeof(int));
            table2.Columns.Add("Fan name", typeof(string));
            table2.Columns.Add("Favorite command", typeof(string));
            table2.Columns.Add("Ticket Number", typeof(int));
            // delete info
            using (ApplicationContext db = new ApplicationContext())
            {
                Ticket ticket = db.Tickets.FirstOrDefault();
                if (ticket != null)
                {
                    // delete object
                    db.Tickets.Remove(ticket);
                    db.SaveChanges();
                }
                var tickets = db.Tickets.ToList();
                //display
                foreach (Ticket t in tickets)
                {
                    table2.Rows.Add(t.Id, t.FanName, t.FavoriteCommand, t.TicketNumber);
                }
            }
            dataGridView3.DataSource = table2;
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
