using System.ServiceModel;

namespace NetChatService.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OperationContext OpContext { get; set; }
    }
}