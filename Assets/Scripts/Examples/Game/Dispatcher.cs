using UnityEngine;
using System.Collections;

namespace UniTEA.Example.Game
{
  public class Dispatcher : MonoBehaviour
  {
    [SerializeField]
    Manager manager;

    void Start()
    {
      StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
      while (true)
      {
        manager.Dispatch(new TickMsg());
        yield return new WaitForSeconds(0.1f);
      }
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.D)) manager.Dispatch(new MoveMsg(Direction.Right));
      if (Input.GetKeyDown(KeyCode.A)) manager.Dispatch(new MoveMsg(Direction.Left));
      if (Input.GetKeyDown(KeyCode.W)) manager.Dispatch(new MoveMsg(Direction.Forward));
      if (Input.GetKeyDown(KeyCode.S)) manager.Dispatch(new MoveMsg(Direction.Backward));
    }
  }
}