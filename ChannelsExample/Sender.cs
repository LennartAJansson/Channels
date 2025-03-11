namespace ChannelsExample;

using System.Threading.Channels;

public class Sender(ILogger<Sender> logger, IMessageService service)
  : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      _ = service.Messages.Writer.WriteAsync(RemoteActionMessage.Create(RemoteActionType.OpenDoorCmd));
      logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      await Task.Delay(10000, stoppingToken);
    }
  }
}

public class Listener1(ILogger<Listener1> logger, IMessageService service)
  : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      await foreach (RemoteActionMessage message in service.Messages.Reader.ReadAllAsync(stoppingToken))
      {
        logger.LogInformation("Received {msg}", message);
      }
      logger.LogInformation("After listening");
    }
  }
}

public class Listener2(ILogger<Listener2> logger, IMessageService service)
  : BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      await foreach (RemoteActionMessage message in service.Messages.Reader.ReadAllAsync(stoppingToken))
      {
        logger.LogInformation("Received {msg}", message);
      }
      logger.LogInformation("After listening");
    }
  }
}

public interface IMessageService
{
  Channel<RemoteActionMessage> Messages { get; }
}

public class MessageService : IMessageService
{
  public Channel<RemoteActionMessage> Messages { get; } = Channel.CreateUnbounded<RemoteActionMessage>();
}