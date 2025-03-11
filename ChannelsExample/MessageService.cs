namespace ChannelsExample;

using System.Threading.Channels;

public class MessageService : IMessageService
{
  public Channel<RemoteActionMessage> Messages { get; } = Channel.CreateUnbounded<RemoteActionMessage>();
}