using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ServiceModel;
using NetChatClient.Service;

namespace NetChat.View
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class ChatPage : Page, IServiceCallback
    {
        public static ServiceClient Client { get; private set; }
        public static int ClientId { get; private set; }

        public ChatPage(string username)
        {
            InitializeComponent();
            Client = new ServiceClient(new InstanceContext(this));              // Create client
            ClientId = Client.Connect(username);                                // Save Id and connecting to the server
            if (Client.State == CommunicationState.Faulted)                     
                throw new EndpointNotFoundException();

            Task.Factory.StartNew(() => Client.GetUpdate());
        }

        public void MessageCallback(string message)
        {
            chatMessages.Items.Add(message);                                                        // Print users message on the screen
            chatMessages.ScrollIntoView(chatMessages.Items[chatMessages.Items.Count - 1]);          // Scroll to the last message          
        }

        public void Update()
        {
            if (Client != null)
            {
                amountUsers.Text = $"users online: {Client.UsersList().Length}";
                usersList.Items.Clear();
                foreach (var user in Client.UsersList())             
                    usersList.Items.Add(user);             
            }
        }

        private void BorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                Application.Current.MainWindow.DragMove();
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Client.Disconnect(ClientId);
            Client = null;    
            Application.Current.Shutdown();
        }

        private void ButtonLeave(object sender, RoutedEventArgs e)
        {
            Client.Disconnect(ClientId);
            Client = null;
            Application.Current.MainWindow.Content = new LoginPage();
        }

        private void MessageKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Client != null)
            {
                Client.SendMessage(messageBox.Text, ClientId);
                messageBox.Text = string.Empty;
            }
        }
    }
}