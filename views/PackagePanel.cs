using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CRM2.Views
{
    public class PackagePanel : Panel
    {
        public List<Package> Data { get; set; }
        public bool ascending = true;
        public int clickedColHeader = 0;
        PackageEditPanel editPanel;
        TableLayoutPanel bottomLayoutPanel;
        public PackagePanel()
        {
            Data = new List<Package>(DatabaseManager.LoadPackages());
            InitializeComponent();
            SortableDataGridView<Package> sdgv = (SortableDataGridView<Package>)bottomLayoutPanel.Controls[0];
        }
        public void InitializeComponent()
        {
            //this panel properties
            Dock = DockStyle.Fill;
            BackColor = Color.primary;
            MinimumSize = new System.Drawing.Size(800, 600);

            //declared controls
            Label title = new Label();
            Button back = new Button();
            Button add = new Button();
            SortableDataGridView<Package> dataGridView = new SortableDataGridView<Package>(Data);
            Panel headerPanel = new Panel();
            TableLayoutPanel mainLayoutPanel = new TableLayoutPanel();
            bottomLayoutPanel = new TableLayoutPanel();
            editPanel = new PackageEditPanel();

            //mainLayoutPanel properties
            mainLayoutPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.ColumnCount = 1;
            mainLayoutPanel.RowCount = 2;
            mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Controls.Add(mainLayoutPanel);

            //bottomLayoutPanel properties
            bottomLayoutPanel.Dock = DockStyle.Fill;
            bottomLayoutPanel.ColumnCount = 2;
            bottomLayoutPanel.RowCount = 1;
            bottomLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            bottomLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0));
            bottomLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayoutPanel.Controls.Add(bottomLayoutPanel, 0, 1);

            //dataGridView properties
            dataGridView.DoubleClick += new EventHandler(DataGridView_DoubleClick);
            dataGridView.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(DataGridView_ColumnHeaderMouseClick);
            bottomLayoutPanel.Controls.Add(dataGridView, 0, 0);

            //editPanel properties
            bottomLayoutPanel.Controls.Add(editPanel, 1, 0);

            //headerPanel properties
            headerPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.Controls.Add(headerPanel, 0, 0);

            //title properties
            title.Name = "title";
            title.Text = "Pakiety";
            title.Dock = DockStyle.Fill;
            title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            title.ForeColor = Color.text;
            title.Font = new System.Drawing.Font("Arial", 36);
            
            //back button properties
            back.Name = "back";
            back.Text = "Cofnij";
            back.Dock = DockStyle.Left;
            back.Click += new EventHandler(Back_Click);
            
            //add button properties
            add.Name = "add";
            add.Text = "Dodaj";
            add.Dock = DockStyle.Right; 
            add.Click += new EventHandler(Add_Click);

            //headerPanel controls
            headerPanel.Controls.Add(title);
            headerPanel.Controls.Add(back);
            headerPanel.Controls.Add(add);
        }

        internal class Button : System.Windows.Forms.Button
        {
            public Button()
            {
                SetStyle(ControlStyles.Selectable, false);
                BackColor = Color.secondary;
                ForeColor = Color.text;
                Font = new System.Drawing.Font("Arial", 12);
                MinimumSize = new System.Drawing.Size(180, 60);
                MaximumSize = new System.Drawing.Size(180, 60);
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        public void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SortableDataGridView<Package> dataGridView = sender as SortableDataGridView<Package>;
            if (e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex != clickedColHeader)
                {
                    clickedColHeader = e.ColumnIndex;
                    ascending = true;
                }
                DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];
                // Handle column header click
                dataGridView.Sort(e.ColumnIndex, ascending);
                ascending = !ascending;
            }
        }
        private void DataGridView_DoubleClick(object sender, EventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            if(dataGridView.CurrentRow != null)
            {
                editPanel.Fill(dataGridView.CurrentRow);
                
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            bottomLayoutPanel.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 60);
            bottomLayoutPanel.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 40);
            editPanel.NoFill();
        }
    }
}
