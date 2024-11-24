namespace IocContainer;

public interface INetworkCommunicator
{
    bool ConnectionEstablished();
}
public class NetworkCommunicator : INetworkCommunicator
{
    public bool ConnectionEstablished()
    {
        Console.WriteLine("Network connection established...");
        return true;
    }
}