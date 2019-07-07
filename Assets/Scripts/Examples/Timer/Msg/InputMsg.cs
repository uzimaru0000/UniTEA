using TEA.Utils;

namespace TEA.Example.Timer
{
  class InputMsg : OneValueMsg<Msg, int>
  {
    public override Msg GetMessage() => Msg.Input;

    public Form form
    {
      get;
    }

    public InputMsg(Form form, int value) : base(value)
    {
      this.form = form;
    }
  }

  enum Form
  {
    Hour,
    Minutes,
    Seconds
  }
}