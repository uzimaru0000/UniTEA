namespace TEA.Example.Todo
{

  class AddTodoMsg : IMessenger<Msg>
  {
    public Msg GetMessage() => Msg.AddTodo;
  }
}