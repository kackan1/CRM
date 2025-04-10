using CRM2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM2.forms
{
    public class PackageForm: Form
    {
        public PackageForm()
        {
            InitializeComponent();
            PackagePanel packagePanel = new PackagePanel();
            packagePanel.Dock = DockStyle.Fill;
            Controls.Add(packagePanel);
        }

        public void InitializeComponent()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Size = ViewManager.form.Size;
            BackColor = Color.primary;
            ForeColor = Color.text;
        }

        protected override void OnResize(EventArgs e)
        {
        }

        protected override void OnResizeBegin(EventArgs e)
        {
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeBegin(e);
            base.OnResize(e);
            base.OnResizeEnd(e);
        }
    }
}
