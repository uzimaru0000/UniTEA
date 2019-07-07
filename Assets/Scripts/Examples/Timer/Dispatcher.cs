using UnityEngine;

namespace TEA.Example.Timer
{
  class Dispatcher : MonoBehaviour
  {
    void OnIncrement(Form form)
      => TEAManager.Instance.Commit(new IncrementMsg(form));

    void OnDecrement(Form form)
      => TEAManager.Instance.Commit(new DecrementMsg(form));

    public void HourIncrement() => OnIncrement(Form.Hour);
    public void MinutesIncrement() => OnIncrement(Form.Minutes);
    public void SecondsIncrement() => OnIncrement(Form.Seconds);
    public void HourDecrement() => OnDecrement(Form.Hour);
    public void MinutesDecrement() => OnDecrement(Form.Minutes);
    public void SecondsDecrement() => OnDecrement(Form.Seconds);

    void Update()
    {
      TEAManager.Instance.Commit(new TimerMsg(Time.deltaTime));
    }
  }
}