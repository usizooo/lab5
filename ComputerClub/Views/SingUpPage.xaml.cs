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
    /// Логика взаимодействия для SingUpPage.xaml
    /// </summary>
    public partial class SingUpPage : Page
    {
        private readonly Frame mainFrame;
        public SingUpPage(Frame mainFrame)
        {
            InitializeComponent();
            this.mainFrame = mainFrame;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
            => mainFrame.Content = new MainMenuPage(mainFrame);

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;

            string warningInfo;
            if (!AdminsController.Instance.TrySignInNewAdmin(login, password, out warningInfo))
            {
                MessageBox.Show(
                   warningInfo,
                   "Не удалось добавить нового админа",
                   MessageBoxButton.OK,
                   MessageBoxImage.Warning);
            }
            else
            MessageBox.Show("Новый пользователь успешно добавлен!");
            loginTextBox.Text = passwordTextBox.Text = string.Empty;
        }
    }
}