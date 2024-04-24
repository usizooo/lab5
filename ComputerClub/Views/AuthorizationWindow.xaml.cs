using ComputerClub.View_Models;
using System.Windows;

namespace ComputerClub.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private bool isFirstLoad = true;
        public AuthorizationWindow()
        {
            InitializeComponent();
            if(isFirstLoad)
            {
                AdminsController.Instance.ToString();
                DevicesController.Instance.ToString();
                OrdersController.Instance.ToString();
                GlobalApplicationSystem.Instance.OnApplicationLoading?.Invoke(this, EventArgs.Empty);
                isFirstLoad = false;
            }
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordBox.Password;

            if (AdminsController.Instance.IsSuccessfulLogin(login, password))
            {
                WindowManager.Instance.OpenNewWindow(new AdminWindow(), this);
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GlobalApplicationSystem.Instance.OnApplicationClosing?.Invoke(this, EventArgs.Empty);
        }
    }
}
