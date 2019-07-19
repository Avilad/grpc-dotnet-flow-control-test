using System;
using System.Threading;
using FlowControlTest.Server.Services;
using Grpc.Core;
using Test;

namespace FlowControlTest.Server.Core
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var server = new Grpc.Core.Server
            {
                Services = {Tester.BindService(new TesterService())},
                Ports = {new ServerPort("0.0.0.0", 5001, ServerCredentials.Insecure)}
            };
            server.Start();

            Console.WriteLine("Listening on port 5001");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
