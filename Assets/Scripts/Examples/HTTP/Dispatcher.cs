using UnityEngine;

namespace UniTEA.Example.HTTP
{
  public class Dispatcher : MonoBehaviour
  {
    [SerializeField]
    TEAManager manager;

    void String2IntMsg(string str, System.Func<int, IMessenger<Msg>> func)
    {
      int value;
      if (int.TryParse(str, out value))
      {
        manager.Dispatch(func(value));
      }
    }

    public void OnWidthInput(string str) => String2IntMsg(str, n => new InputWidthMsg(n));
    public void OnHeightInput(string str) => String2IntMsg(str, n => new InputHeightMsg(n));
    public void OnRequest() => manager.Dispatch(new RequestMsg());
  }
}