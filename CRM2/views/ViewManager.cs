using System.Windows.Forms;

namespace CRM2.Views
{
    public static class ViewManager
    {
        public static Form form;
        public static Panel previousPanel;
        public static void SwitchView(Panel fromPanel, Panel toPanel)
        {
            previousPanel = fromPanel;
            form.Controls.Clear();
            form.Controls.Add(toPanel);
        }
        public static void BackToView()
        {
            form.Controls.Clear();
            form.Controls.Add(previousPanel);
        }
    }
}
