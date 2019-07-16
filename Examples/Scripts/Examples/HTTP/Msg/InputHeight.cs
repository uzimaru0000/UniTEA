using UniTEA.Utils;

namespace UniTEA.Example.HTTP
{
  class InputHeightMsg : OneValueMsg<Msg, int>
  {
    public override Msg GetMessage() => Msg.InputHeight;
    public InputHeightMsg(int value) : base(value) { }
  }
}