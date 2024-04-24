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
    /// Логика взаимодействия для NewOrderPage.xaml
    /// </summary>
    public partial class NewOrderPage : Page
    {
        private readonly Frame mainFrame;
        public NewOrderPage(Frame mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;
            rentTimeInMinuteIntegerUpDown.Minimum = 0;
            rentTimeInMinuteIntegerUpDown.Maximum = 120;
            rentTimeInMinuteIntegerUpDown.Value = 0;
            deviceNameComboBox.ItemsSource 
                = DevicesController.Instance.GetDeviceList().Select(x => x.Name).ToList();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.Content = new MainMenuPage(mainFrame);

        private void pushNewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (deviceNameComboBox.SelectedItem == null)
            {
                MessageBox.Show("Устройство не выбрано!");
                return;
            }

            var deviceName = deviceNameComboBox.SelectedItem.ToString()
                ?? throw new ArgumentNullException(nameof(deviceNameComboBox.SelectedItem));
            var rentTimeInMinute = rentTimeInMinuteIntegerUpDown.Value
                ?? throw new ArgumentNullException(nameof(rentTimeInMinuteIntegerUpDown.Value));

            if (rentTimeInMinute == 0)
            {
                MessageBox.Show("Время аренды устройства не может быть нулевым!");
                return;
            }

            string warningInfo;
            if(!OrdersController.Instance.TryPushNewOrder(deviceName, rentTimeInMinute, out warningInfo))
            {
                MessageBox.Show(
                   warningInfo,
                   "Не удалось добавить заказ",
                   MessageBoxButton.OK,
                   MessageBoxImage.Warning);
            }
            MessageBox.Show("Заказ успешно добавлен!");
            rentTimeInMinuteIntegerUpDown.Value = 0;
        }

        private void deviceTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            => UpdateCurrentPrice();

        private void rentTimeIntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
            => UpdateCurrentPrice();

        private void UpdateCurrentPrice()
        {
            if (deviceNameComboBox.SelectedItem != null && rentTimeInMinuteIntegerUpDown.Value != null)
            {
                var deviceName = deviceNameComboBox.SelectedItem.ToString()
                    ?? throw new ArgumentNullException(nameof(deviceNameComboBox.SelectedItem));
                var rentTimeInMinute = rentTimeInMinuteIntegerUpDown.Value
                    ?? throw new ArgumentNullException(nameof(rentTimeInMinuteIntegerUpDown.Value));
                priceLabel.Content = DevicesController.Instance.GetTotalAmount(deviceName, rentTimeInMinute);
            }
        }
    }
}
