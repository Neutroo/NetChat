using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.ServiceModel;
using NetChatClient.Service;

namespace NetChat.View
{
    public partial class ChatPage : Page, IServiceCallback
    {
        public static ServiceClient Client { get; set; }
        public static int ClientId { get; set; }
        public static string Username { get; set; }

        public ChatPage()
        {
            InitializeComponent();
            Client = new ServiceClient(new InstanceContext(this));              // Создаем клиента
            ClientId = Client.Connect(Username);                                // Запоминаем Id и присоединяемся к сервису
            if (Client.State == CommunicationState.Faulted)                     // Если ошибка в состоянии объекта
                throw new EndpointNotFoundException();
        }

        public void MessageCallback(string message)
        {
            ChatMessages.Items.Add(message);                                                        // Выводим сообщения от пользователя на экран
            ChatMessages.ScrollIntoView(ChatMessages.Items[ChatMessages.Items.Count - 1]);          // Скролим до самого последнего сообщения           
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
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
                Client.SendMessage(MessageBox.Text, ClientId);
                MessageBox.Text = string.Empty;
            }
        }
    }
}