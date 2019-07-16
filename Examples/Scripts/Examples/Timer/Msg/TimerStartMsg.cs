namespace UniTEA.Example.Timer
{
  class TimerStartMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.TimerStart;
  }
}