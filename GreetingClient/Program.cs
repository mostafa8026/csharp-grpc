using Grpc.Core;
using Helloworld;
using System;

namespace GreetingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);
            String user = "CSharp";

            var reply = client.SayHello(new HelloRequest { Name = user });
            Console.WriteLine("Greeting: " + reply.Message);

            channel.ShutdownAsync().Wait();
        }
    }
}
