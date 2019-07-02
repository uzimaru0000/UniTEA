using UnityEngine;

namespace TEA.Example.Counter
{
  public class Dispacher : MonoBehaviour
  {
    [SerializeField]
    TEAManager manager;

    public void Increment()
    {
      manager.Commit(new IncrementMsg());
    }

    public void Decrement()
    {
      manager.Commit(new DecrementMsg());
    }
  }

}