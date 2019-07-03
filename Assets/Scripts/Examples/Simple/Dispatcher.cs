using UnityEngine;
using TEA;

namespace TEA.Example.Simple
{

  public class Dispatcher : MonoBehaviour
  {
    [SerializeField]
    TEAManager manager;

    public void ChangeName(string str)
    {
      manager.Commit(new NameChanger(str));
    }

    public void ChangeAge(string str)
    {
      int n;
      if (int.TryParse(str, out n))
      {
        manager.Commit(new AgeChanger(n));
      }
    }
  }

}