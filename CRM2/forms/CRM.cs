using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM2
{
    public class CRM : Form
    {
        public CRM()
        {
            Text = "CRM";
            Width = 1200;
            Height = 800;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Controls.Add(new Views.MenuPanel());
        }
    }
}
