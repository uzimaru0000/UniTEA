namespace TEA.Example.Todo
{
  class InputMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.Input;

    public string value
    {
      get;
    }

    public InputMsg(string str)
    {
      value = str;
    }
  }
}