using UniTEA.Utils;

namespace UniTEA.Example.Todo
{
  class InputMsg : OneValueMsg<Msg, string>
  {
    public override Msg GetMessage() => Msg.Input;
    public InputMsg(string str) : base(str) { }
  }
}