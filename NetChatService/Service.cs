using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using NetChatService.Model;

namespace NetChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]     // Create single server for all users
    public class Service : IService
    {
        private List<User> users = new List<User>();   // List of users connected to the service
        private int genId = 1;                         // To create unique id for users 

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
            User user = users.FirstOrDefault(u => u.Id == id);         // Search for user by id for the user list
            if (user != null)                                          // If there is one
            {
                users.Remove(user);                                    // Remove it
                SendMessage($"{user.Name} left the chat.");
            }

            GetUpdate();
        }

        public void SendMessage(string message, int id = 0)
        {
            foreach (var elem in users)
            {
                var user = users.FirstOrDefault(u => u.Id == id);                   // Search for user by id for the user list

                string answer = (user != null) ?
                    $"{user.Name} {DateTime.Now.ToShortTimeString()}\n{message}" :  // User message
                    $"{message} {DateTime.Now.ToShortTimeString()}";                // Message about connection/disconnection of the user

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