using System.ServiceModel;
using System.Collections.Generic;
using NetChatService.Model;


namespace NetChatService
{
    [ServiceContract(CallbackContract = typeof(IServerCallback))]
    public interface IService
    {
        [OperationContract]
        int Connect(string name);                       // Подключение пользователя к сервису
        [OperationContract]
        void Disconnect(int id);                        // Отключение пользователя от сервиса
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, int id = 0);   // Отправка сообщения от пользователя - сервису
        [OperationContract]
        IEnumerable<string> UsersList();                // Получение списка пользователей
    }

    public interface IServerCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message);           // Отправка сообщения от сервиса всем пользователям
    }
}