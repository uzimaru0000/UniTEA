namespace TEA.Example.Counter
{
  public enum Msg
  {
    Increment,
    Decrement
  }

  class IncrementMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.Increment;
  }

  class DecrementMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.Decrement;
  }
}