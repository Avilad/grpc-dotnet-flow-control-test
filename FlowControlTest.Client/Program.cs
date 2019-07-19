using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Grpc.Core;
using Test;

namespace FlowControlTest.Client
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var sw = new Stopwatch();

            if (args.Length < 1)
            {
                Console.Out.WriteLine("Usage: dotnet run --project FlowControlTest.Client server_host:port");
                return;
            }

            var channel = new Channel(args[0],
                ChannelCredentials.Insecure);
            var client = new Tester.TesterClient(channel);

            var call = client.StreamData();
            for (var i = 0; i < 10000; ++i)
            {
                sw.Start();
                await call.RequestStream.WriteAsync(new TestRequest
                {
                    Data = new string('a', 10000)
                });
                sw.Stop();
                Console.Out.WriteLine("Sent request {0} in {1}s", i, sw.Elapsed);
                sw.Reset();
            }

            await call.RequestStream.CompleteAsync();

            await call.ResponseAsync;

            await channel.ShutdownAsync();
        }
    }
}
