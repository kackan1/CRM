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
            Width = 800;
            Height = 600;
            Controls.Add(new Views.MenuPanel());
        }
    }
}
