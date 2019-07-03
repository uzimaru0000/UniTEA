using System.Collections.Immutable;

namespace TEA.Example.Todo
{
  public struct Model
  {
    public string input;
    public ImmutableList<Todo> todoList;
  }

  [System.Serializable]
  public struct Todo
  {
    public int id;
    public string title;
    public bool isDone;
  }
}