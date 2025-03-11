using ChannelsExample;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Sender>();
builder.Services.AddHostedService<Listener1>();
builder.Services.AddHostedService<Listener2>();
builder.Services.AddSingleton<IMessageService, MessageService>();

IHost host = builder.Build();
host.Run();
