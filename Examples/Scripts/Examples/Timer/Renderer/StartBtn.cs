using UnityEngine;
using UI = UnityEngine.UI;

namespace UniTEA.Example.Timer
{
  [RequireComponent(typeof(UI.Button))]
  public class StartBtn : MonoBehaviour
  {
    TimerState state;

    internal TimerState State
    {
      set
      {
        state = value;
        ChangeView();
      }
    }

    UI.Text _label;

    UI.Text Label
    {
      get
      {
        if (!_label) _label = GetComponentInChildren<UI.Text>();
        return _label;
      }
    }

    void Start()
    {
      GetComponent<UI.Button>().onClick.AddListener(() =>
      {
        switch (state)
        {
          case TimerState.Stop:
            TEAManager.Instance.Dispatch(new TimerStartMsg());
            break;

          case TimerState.Running:
            TEAManager.Instance.Dispatch(new TimerStopMsg());
            break;
        }
      });
    }

    void ChangeView()
    {
      switch (state)
      {
        case TimerState.Stop:
          Label.text = "Start";
          break;
        case TimerState.Running:
          Label.text = "Stop";
          break;
      }
    }

  }

}