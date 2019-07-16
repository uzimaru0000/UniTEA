using UnityEngine;

namespace UniTEA.Example.Todo
{
  public class Dispatcher : MonoBehaviour
  {
    public void OnInput(string str)
    {
      TEAManager.Instance.Dispatch(new InputMsg(str));
    }

    public void OnClick()
    {
      TEAManager.Instance.Dispatch(new AddTodoMsg());
    }
  }
}