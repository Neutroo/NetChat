using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            if (e.LeftButton == MouseButtonState.Pressed) 
                Application.Current.MainWindow.DragMove();    
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
                    Application.Current.MainWindow.Content = new ChatPage(Username.Text);    // Going to the page with chat
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