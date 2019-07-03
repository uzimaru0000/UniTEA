using UnityEngine;

namespace TEA.Example.Todo
{
  public class Dispatcher : MonoBehaviour
  {
    public void OnInput(string str)
    {
      TEAManager.Instance.Commit(new InputMsg(str));
    }

    public void OnClick()
    {
      TEAManager.Instance.Commit(new AddTodoMsg());
    }
  }
}