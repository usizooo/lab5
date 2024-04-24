using ComputerClub.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputerClub.Views
{
    /// <summary>
    /// Логика взаимодействия для OutputDevicesPage.xaml
    /// </summary>
    public partial class OutputDevicesPage : Page
    {
        private readonly Frame mainFrame;
        public OutputDevicesPage(Frame mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;

            devicesDataGrid.ItemsSource = DevicesController.Instance.GetDeviceList();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.Content = new MainMenuPage(mainFrame);
    }
}
