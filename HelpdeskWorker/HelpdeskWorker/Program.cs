using HelpdeskWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //services.AddHostedService<Worker>();
        services.AddHostedService<WorkerGetMail>();
    })
    .Build();

await host.RunAsync();
