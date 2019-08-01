using UnityEngine;
using UniTEA;

namespace UniTEA.Example.Simple
{

  public class Dispatcher : MonoBehaviour
  {
    [SerializeField]
    TEAManager manager;

    public void ChangeName(string str)
    {
      manager.Dispatch(new NameChanger(str));
    }

    public void ChangeAge(string str)
    {
      int n;
      if (int.TryParse(str, out n))
      {
        manager.Dispatch(new AgeChanger(n));
      }
    }
  }

}