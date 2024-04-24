using System.Windows;

namespace ComputerClub.Views
{
    public class WindowManager : Singleton
    {
        public static WindowManager Instance => Instance<WindowManager>();
        private WindowManager() { }
        public void OpenNewWindow(Window to, Window from)
        {
            to.Closing += delegate { from.Show(); };
            to.Show();
            from.Hide();
        }
    }
}