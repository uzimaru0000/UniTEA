using UnityEngine;
using UI = UnityEngine.UI;

namespace TEA.Example.Timer
{
  [RequireComponent(typeof(UI.InputField))]
  public class Display : MonoBehaviour
  {
    [SerializeField]
    Form formType;

    UI.InputField _field;
    UI.InputField field
    {
      get
      {
        if (_field == null) _field = GetComponent<UI.InputField>();
        return _field;
      }
    }

    TimerState state;
    internal TimerState State
    {
      set
      {
        state = value;
        ChangeState();
      }
    }

    string _value;
    internal string Value
    {
      get => _value;
      set
      {
        _value = value;
        ChangeValue();
      }
    }

    void Start()
    {
      field.onValueChanged.AddListener(x =>
      {
        if (state != TimerState.Stop) return;
        int num;
        if (int.TryParse(x, out num))
        {
          TEAManager.Instance.Commit(new InputMsg(formType, num));
        }
      });
    }

    void ChangeState()
    {
      switch (state)
      {
        case TimerState.Stop:
          field.readOnly = true;
          break;
        case TimerState.Running:
          field.readOnly = false;
          break;
      }
    }

    void ChangeValue()
    {
      field.text = Value;
    }

  }
}