using TEA.Utils;

namespace TEA.Example.Todo
{

  class DoneMsg : OneValueMsg<Msg, int>
  {
    public override Msg GetMessage() => Msg.Done;
    public DoneMsg(int value) : base(value) { }
  }
}