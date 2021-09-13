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

namespace NetChat.View
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) Application.Current.MainWindow.DragMove();    
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonLogIn(object sender, RoutedEventArgs e)
        {
            if (Username.Text != string.Empty)
            {
                try
                {
                    ChatPage.Username = Username.Text;                          // Передаем имя пользователя 
                    Application.Current.MainWindow.Content = new ChatPage();    // Переходим на страницу с чатом
                }
                catch (System.ServiceModel.EndpointNotFoundException)
                {
                    Application.Current.MainWindow.Content = new ServerErrorPage();
                }
            }
            else
            {
                ValidationError.Text = "*Username is required.";
                ValidationError.Visibility = Visibility.Visible;
            }
        }
    }
}