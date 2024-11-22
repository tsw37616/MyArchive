var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MyArchive_ApiService>("apiservice");

builder.AddProject<Projects.MyArchive_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
