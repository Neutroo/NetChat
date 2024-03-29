﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetChatClient.Service {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.IService", CallbackContract=typeof(NetChatClient.Service.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Connect", ReplyAction="http://tempuri.org/IService/ConnectResponse")]
        int Connect(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Connect", ReplyAction="http://tempuri.org/IService/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconnect", ReplyAction="http://tempuri.org/IService/DisconnectResponse")]
        void Disconnect(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Disconnect", ReplyAction="http://tempuri.org/IService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/SendMessage")]
        void SendMessage(string message, int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string message, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UsersList", ReplyAction="http://tempuri.org/IService/UsersListResponse")]
        string[] UsersList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UsersList", ReplyAction="http://tempuri.org/IService/UsersListResponse")]
        System.Threading.Tasks.Task<string[]> UsersListAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/GetUpdate")]
        void GetUpdate();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/GetUpdate")]
        System.Threading.Tasks.Task GetUpdateAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/MessageCallback")]
        void MessageCallback(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Update")]
        void Update();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : NetChatClient.Service.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<NetChatClient.Service.IService>, NetChatClient.Service.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int Connect(string name) {
            return base.Channel.Connect(name);
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync(string name) {
            return base.Channel.ConnectAsync(name);
        }
        
        public void Disconnect(int id) {
            base.Channel.Disconnect(id);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(int id) {
            return base.Channel.DisconnectAsync(id);
        }
        
        public void SendMessage(string message, int id) {
            base.Channel.SendMessage(message, id);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string message, int id) {
            return base.Channel.SendMessageAsync(message, id);
        }
        
        public string[] UsersList() {
            return base.Channel.UsersList();
        }
        
        public System.Threading.Tasks.Task<string[]> UsersListAsync() {
            return base.Channel.UsersListAsync();
        }
        
        public void GetUpdate() {
            base.Channel.GetUpdate();
        }
        
        public System.Threading.Tasks.Task GetUpdateAsync() {
            return base.Channel.GetUpdateAsync();
        }
    }
}
