namespace ChannelsExample;

using System.Threading.Channels;

public interface IMessageService
{
  Channel<RemoteActionMessage> Messages { get; }
}
