using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetChat.View
{
    public partial class ServerErrorPage : Page
    {
        public ServerErrorPage()
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
    }
}