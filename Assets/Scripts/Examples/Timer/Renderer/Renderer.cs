using UnityEngine;

namespace UniTEA.Example.Timer
{
  class Renderer : MonoBehaviour, IRenderer<Model>
  {
    [SerializeField]
    Display hour;
    [SerializeField]
    Display minutes;
    [SerializeField]
    Display seconds;

    [SerializeField]
    StartBtn startBtn;

    [SerializeField]
    ResetBtn resetButton;

    public void Render(Model model)
    {
      ChangeInputState(model.state);
      ChangeValue(model.timer);
      startBtn.State = model.state;
      resetButton.State = model.state;
    }

    void ChangeInputState(TimerState state)
    {
      hour.State = state;
      minutes.State = state;
      seconds.State = state;
    }

    void ChangeValue(float timer)
    {
      var h = Mathf.FloorToInt(timer / 3600);
      var m = Mathf.FloorToInt((timer % 3600) / 60);
      var s = Mathf.FloorToInt(timer % 60);

      hour.Value = h.ToString();
      minutes.Value = m.ToString();
      seconds.Value = s.ToString();
    }

  }
}