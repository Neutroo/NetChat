using System.ServiceModel;
using System.Collections.Generic;


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
        [OperationContract(IsOneWay = true)]
        void GetUpdate();                               // Запрос на обновление
    }

    public interface IServerCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message);           // Отправка сообщения от сервиса всем пользователям
        [OperationContract(IsOneWay = true)]
        void Update();                                  // Обновление данных
    }
}