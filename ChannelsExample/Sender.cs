namespace ChannelsExample;
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
