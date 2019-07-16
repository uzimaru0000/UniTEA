using UnityEngine;

namespace UniTEA.Example.Counter
{
  public class Dispacher : MonoBehaviour
  {
    [SerializeField]
    TEAManager manager;

    public void Increment()
    {
      manager.Dispatch(new IncrementMsg());
    }

    public void Decrement()
    {
      manager.Dispatch(new DecrementMsg());
    }
  }

}