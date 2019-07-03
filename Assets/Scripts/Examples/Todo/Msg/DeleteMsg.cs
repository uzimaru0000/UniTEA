namespace TEA.Example.Todo
{

  class DoneMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.Done;

    public int id
    {
      get;
    }

    public DoneMsg(int id)
    {
      this.id = id;
    }
  }
}