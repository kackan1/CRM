using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM2.Views
{
    class MenuPanel : Panel
    {
        public MenuPanel()
        {
            InitializeComponent();
        }
        public void InitializeComponent()
        {
            //this panel properties
            Dock = DockStyle.Fill;
            BackColor = System.Drawing.Color.DarkViolet;
            
            //declared controls
            Button tickets = new Button();
            Button hours = new Button();
            Button package = new Button();
            Button exit = new Button();
            TableLayoutPanel layout = new TableLayoutPanel();

            //layout properties
            layout.Dock = DockStyle.Fill;
            layout.ColumnCount = 3;
            layout.RowCount = 6;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            this.Controls.Add(layout);
            layout.Controls.Add(tickets, 1, 1);
            layout.Controls.Add(hours, 1, 2);
            layout.Controls.Add(package, 1, 3);
            layout.Controls.Add(exit, 1, 4);

            //tickets button properties
            tickets.Name = "tickets";
            tickets.Text = "Zgłoszenia";
            tickets.MinimumSize = new System.Drawing.Size(100, 50);
            tickets.MaximumSize = new System.Drawing.Size(200, 100);
            tickets.Dock = DockStyle.Fill;
            tickets.BackColor = System.Drawing.Color.White;
            tickets.Font = new System.Drawing.Font("Arial", 12);
            tickets.Click += new EventHandler(Tickets_Click);
        }

        private void Tickets_Click(object sender, EventArgs e)
        {
            ViewManager.SwitchView(this, new TicketPanel());
        }
        private void Hours_Click(object sender, EventArgs e)
        {
            ViewManager.SwitchView(this, new HoursPanel());
        }
        private void Package_Click(object sender, EventArgs e)
        {
            ViewManager.SwitchView(this, new PackagePanel());
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
