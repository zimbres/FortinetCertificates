var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHttpClient("Default");
builder.Services.AddHttpClient("IgnoreSSL")
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
    };
});
builder.Services.AddSingleton<CertInfoService>();
builder.Services.AddSingleton<AgentService>();
builder.Services.AddSingleton<WorkerService>();
builder.Services.AddSingleton<LogService>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddHostedService<Worker>().Configure<HostOptions>(options =>
{
    options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
});
builder.Services.AddSingleton<IHealthCheckPublisher, HealthCheckPublisher>();
builder.Services.Configure<HealthCheckPublisherOptions>(options =>
{
    options.Delay = TimeSpan.FromSeconds(5);
    options.Period = TimeSpan.FromSeconds(20);
});

var host = builder.Build();
host.Run();
