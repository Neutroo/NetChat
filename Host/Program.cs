using System;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(NetChatService.Service)))
            {
                host.Open();
                Console.WriteLine("Host was started.");
                Console.ReadLine();
            }
        }
    }
}