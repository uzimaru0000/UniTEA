namespace TEA.Example.Timer
{
  class TimerResetMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.TimerReset;
  }
}