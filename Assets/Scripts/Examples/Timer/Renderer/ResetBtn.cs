using UnityEngine;
using UI = UnityEngine.UI;

namespace UniTEA.Example.Timer
{
  [RequireComponent(typeof(UI.Button))]
  public class ResetBtn : MonoBehaviour
  {
    TimerState state;
    internal TimerState State
    {
      set
      {
        state = value;
        ChangeState();
      }
    }
    UI.Button btn;

    void Start()
    {
      btn = GetComponent<UI.Button>();
      btn.onClick.AddListener(() => TEAManager.Instance.Dispatch(new TimerResetMsg()));
    }

    void ChangeState()
    {
      switch (state)
      {
        case TimerState.Running:
          btn.interactable = false;
          break;
        case TimerState.Stop:
          btn.interactable = true;
          break;
      }
    }
  }
}