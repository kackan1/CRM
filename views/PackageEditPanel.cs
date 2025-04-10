using System.Windows.Forms;

namespace CRM2.Views
{
    public class PackageEditPanel : Panel
    {
        public PackageEditPanel()
        {
            InitializeComponent();
        }

        public void Fill(DataGridViewRow row)
        {

        }
        public void NoFill()
        {
            this.Show();
        }
        public void Collapse()
        {

        }

        public void InitializeComponent()
        {
            Dock = DockStyle.Fill;
        }
    }
}