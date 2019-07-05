using TEA.Utils;

namespace TEA.Example.Todo
{
  class DeleteMsg : OneValueMsg<Msg, int>
  {
    public override Msg GetMessage() => Msg.Delete;
    public DeleteMsg(int id) : base(id) { }
  }
}