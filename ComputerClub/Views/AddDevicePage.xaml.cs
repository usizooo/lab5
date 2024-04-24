using ComputerClub.Models;
using ComputerClub.View_Models;
using System.Windows;
using System.Windows.Controls;

namespace ComputerClub.Views
{
    /// <summary>
    /// Логика взаимодействия для AddDevicePage.xaml
    /// </summary>
    public partial class AddDevicePage : Page
    {
        private readonly Frame mainFrame;
        public AddDevicePage(Frame mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;
            priceIntegerUpDown.Minimum = 0;
            priceIntegerUpDown.Value = 0;
            priceIntegerUpDown.Maximum = 300;
            deviceTypeComboBox.ItemsSource = DevicesController.Instance.GetDeviceTypes();
        }

        private void addNewDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            var name = deviceNameTextBox.Text;
            var type = (DeviceType) deviceTypeComboBox.SelectedIndex;
            var price = priceIntegerUpDown.Value 
                ?? throw new ArgumentNullException(nameof(priceIntegerUpDown.Value));
            
            if (price == 0)
            {
                MessageBox.Show("Цена аренды устройства не может быть нулевой!");
                return;
            }

            string warningInfo;
            if(!DevicesController.Instance.TryAddNewDevice(
                new Device(name, type, price), out warningInfo))
            {
                MessageBox.Show(
                    warningInfo,
                    "Не удалось добавить устройство",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show("Устройство добавлено!");
            deviceNameTextBox.Text = string.Empty;
            priceIntegerUpDown.Value = 0;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.Content = new MainMenuPage(mainFrame);
    }
}
