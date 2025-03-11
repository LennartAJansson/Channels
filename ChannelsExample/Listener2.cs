namespace ChannelsExample;

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
