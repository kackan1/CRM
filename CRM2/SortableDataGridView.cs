using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CRM2
{
    public class SortableDataGridView<T> : DataGridView
    {
        List<T> list = new List<T>();
        bool ascending = false;
        public SortableDataGridView(List<T> list)
        {
            this.list = list;
            DataBindings.Clear();
            DataSource = list;
            Sort(0, !ascending);
            InitializeComponent();
        }
        public void Sort(int colIndex, bool ascending)
        {
            this.ascending = !ascending;
            if (ascending)
                list = list.OrderBy(x => x.GetType().GetProperties()[colIndex].GetValue(x, null)).ToList();
            else
            {
                list = list.OrderBy(x => x.GetType().GetProperties()[colIndex].GetValue(x, null)).ToList();
                list.Reverse();
            }
            DataSource = list;
            Refresh();
        }
        public void InitializeComponent()   
        {
            Dock = DockStyle.Fill;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            BorderStyle = BorderStyle.FixedSingle;
            BackgroundColor = Color.primary;
            RowHeadersVisible = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = true;
            AllowUserToResizeRows = false;
            DefaultCellStyle.BackColor = Color.primary;
            ReadOnly = true;
            ScrollBars = ScrollBars.Both;
        }
    }
}
