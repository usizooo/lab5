using ComputerClub.View_Models;
using System.Windows;
using System.Windows.Controls;

namespace ComputerClub.Views
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        private readonly Frame mainFrame;
        public MainMenuPage(Frame mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;
            if (AdminsController.Instance.CurrentAdmin != null)
            {
                adminInfoLabel.Content = AdminsController.Instance.CurrentAdmin.Login;
            }
        }

        private void addNewDeviceButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.Content = new AddDevicePage(mainFrame);

        private void outputDevicesButton_Click(object sender, RoutedEventArgs e) 
            => mainFrame.Content = new OutputDevicesPage(mainFrame);

        private void newOrderButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.Content = new NewOrderPage(mainFrame);

        private void logsButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.Content = new OutputLogsPage(mainFrame);

        private void singUpButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.Content = new SingUpPage(mainFrame);
    }
}
