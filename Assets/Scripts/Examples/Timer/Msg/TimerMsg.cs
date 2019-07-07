using TEA.Utils;

namespace TEA.Example.Timer
{
  class TimerMsg : OneValueMsg<Msg, float>
  {
    public override Msg GetMessage() => Msg.Timer;

    public TimerMsg(float value) : base(value) { }
  }
}