using UniTEA.Utils;

namespace UniTEA.Example.Timer
{
  class IncrementMsg : OneValueMsg<Msg, Form>
  {
    public override Msg GetMessage() => Msg.Increment;
    public IncrementMsg(Form form) : base(form) { }
  }
}