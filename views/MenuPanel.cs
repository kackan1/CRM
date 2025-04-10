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
            BackColor = Color.primary;
            MinimumSize = new System.Drawing.Size(800, 600);


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
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.Controls.Add(layout);
            
            //tickets button properties
            tickets.Name = "tickets";
            tickets.Text = "Zgłoszenia";
            tickets.Click += new EventHandler(Tickets_Click);
            layout.Controls.Add(tickets, 1, 1);

            //hours button properties
            hours.Name = "hours";
            hours.Text = "Godziny";
            hours.Click += new EventHandler(Hours_Click);
            layout.Controls.Add(hours, 1, 2);

            //package button properties
            package.Name = "package";
            package.Text = "Pakiety";
            package.Click += new EventHandler(Package_Click);
            layout.Controls.Add(package, 1, 3);

            //exit button properties
            exit.Name = "exit";
            exit.Text = "Wyjście";
            exit.Click += new EventHandler(Exit_Click);
            layout.Controls.Add(exit, 1, 4);
        }

        internal class Button : System.Windows.Forms.Button
        {
            public Button()
            {
                SetStyle(ControlStyles.Selectable, false);
                Dock = DockStyle.Fill;
                BackColor = Color.secondary;
                ForeColor = Color.text;
                Font = new System.Drawing.Font("Arial", 12);
                MinimumSize = new System.Drawing.Size(180, 60);
                MaximumSize = new System.Drawing.Size(180, 60);
            }
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
            ViewManager.OpenPackageForm();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
