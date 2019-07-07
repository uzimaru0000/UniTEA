namespace TEA.Example.Timer
{
  class TimerStopMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.TimerStop;
  }
}