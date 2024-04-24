using ComputerClub.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ComputerClub.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static EventHandler? OnAdminWindowClosed;
        public AdminWindow()
        {
            InitializeComponent();
            frame.Content = new MainMenuPage(frame);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OnAdminWindowClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
