using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
    }

    public interface IServerCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message);           // Отправка сообщения от сервиса - всем пользователям
    }
}