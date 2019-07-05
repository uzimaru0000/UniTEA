using TEA.Utils;

namespace TEA.Example.Todo
{
  class InputMsg : OneValueMsg<Msg, string>
  {
    public override Msg GetMessage() => Msg.Input;
    public InputMsg(string str) : base(str) { }
  }
}