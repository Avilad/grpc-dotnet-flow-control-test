using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Test;

namespace FlowControlTest.Server.Services
{
    public class TesterService : Tester.TesterBase
    {
        public override async Task<TestReply> StreamData(IAsyncStreamReader<TestRequest> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                await Task.Delay(10);
            }
            return new TestReply();
        }
    }
}
