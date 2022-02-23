using System.Windows;
using System.Windows.Input;

namespace NetChat.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new LoginPage();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(ChatPage.Client != null)
                ChatPage.Client.Disconnect(ChatPage.ClientId);
        }
    }
}