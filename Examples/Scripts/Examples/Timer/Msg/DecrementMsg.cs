using UniTEA.Utils;

namespace UniTEA.Example.Timer
{
  class DecrementMsg : OneValueMsg<Msg, Form>
  {
    public override Msg GetMessage() => Msg.Decrement;
    public DecrementMsg(Form form) : base(form) { }
  }
}