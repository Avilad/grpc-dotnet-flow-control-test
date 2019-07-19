# grpc-dotnet-flow-control-test

Start the servers:\
`docker-compose up`

Test grpc-dotnet:\
`dotnet run --project FlowControlTest.Client localhost:5000`

Test grpc-core:\
`dotnet run --project FlowControlTest.Client localhost:5001`
