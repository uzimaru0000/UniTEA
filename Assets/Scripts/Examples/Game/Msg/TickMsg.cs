namespace UniTEA.Example.Game
{
  public class TickMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.Tick;
  }
}