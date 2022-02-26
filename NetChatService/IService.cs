using System.ServiceModel;
using System.Collections.Generic;


namespace NetChatService
{
    [ServiceContract(CallbackContract = typeof(IServerCallback))]
    public interface IService
    {
        [OperationContract]
        int Connect(string name);                       // Connect user to the server
        [OperationContract]
        void Disconnect(int id);                        // Disconnect user from the server
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, int id = 0);   // Send message from the user to the server
        [OperationContract]
        IEnumerable<string> UsersList();                // Get list of the users
        [OperationContract(IsOneWay = true)]
        void GetUpdate();                               // Request to update
    }

    public interface IServerCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message);           // Send message from server to all users 
        [OperationContract(IsOneWay = true)]
        void Update();                                  // Data update
    }
}