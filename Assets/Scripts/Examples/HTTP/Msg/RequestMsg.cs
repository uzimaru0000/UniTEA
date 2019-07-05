namespace TEA.Example.HTTP
{
  public class RequestMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.Request;
  }
}