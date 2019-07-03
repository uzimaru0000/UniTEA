namespace TEA.Example.Todo
{
  class DeleteMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.Delete;

    public int id
    {
      get;
    }

    public DeleteMsg(int id)
    {
      this.id = id;
    }
  }
}