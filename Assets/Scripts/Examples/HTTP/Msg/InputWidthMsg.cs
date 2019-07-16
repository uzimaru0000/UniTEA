using UniTEA.Utils;

namespace UniTEA.Example.HTTP
{
  class InputWidthMsg : OneValueMsg<Msg, int>
  {
    public override Msg GetMessage() => Msg.InputWidth;
    public InputWidthMsg(int value) : base(value) { }
  }
}