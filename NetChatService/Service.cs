using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using NetChatService.Model;

namespace NetChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]     // Создание единого сервиса для всех клиентов
    public class Service : IService
    {
        private List<User> users = new List<User>();   // Список пользователей присоединенных к сервису
        private int genId = 1;                         // Для создания уникального id пользователя

        public int Connect(string name)
        {
            User user = new User()
            {
                Id = genId++,                          
                Name = name,
                OpContext = OperationContext.Current
            };

            SendMessage($"{user.Name} joined the chat.");
            users.Add(user);

            return user.Id;
        }

        public void Disconnect(int id) 
        {
            User user = users.FirstOrDefault(u => u.Id == id);         // Ищем пользователя из списка по id
            if (user != null)                                           // Если такой есть
            {
                users.Remove(user);                                    // Удаляем
                SendMessage($"{user.Name} left the chat.");
            }

            GetUpdate();
        }

        public void SendMessage(string message, int id = 0)
        {
            foreach (var elem in users)
            {
                var user = users.FirstOrDefault(u => u.Id == id);                  // Ищем пользователя из списка по id

                string answer = (user != null) ?
                    $"{user.Name} {DateTime.Now.ToShortTimeString()}\n{message}" :  // Сообщение пользователя
                    $"{message} {DateTime.Now.ToShortTimeString()}";                // Сообщения о подключении/отключении пользователя

                elem.OpContext.GetCallbackChannel<IServerCallback>().MessageCallback($"{answer}");               
            }
        }

        public void GetUpdate()
        {
            Task.Factory.StartNew(() =>
            {
                foreach (User elem in users)
                    elem.OpContext.GetCallbackChannel<IServerCallback>().Update();
            });
        }

        public IEnumerable<string> UsersList()
        {
            foreach (User user in users)
                yield return user.Name;
        }
    }
}