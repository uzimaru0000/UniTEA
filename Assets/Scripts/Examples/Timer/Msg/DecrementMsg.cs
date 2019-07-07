using TEA.Utils;

namespace TEA.Example.Timer
{
  class DecrementMsg : OneValueMsg<Msg, Form>
  {
    public override Msg GetMessage() => Msg.Decrement;
    public DecrementMsg(Form form) : base(form) { }
  }
}