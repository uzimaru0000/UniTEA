using UnityEngine;
using UI = UnityEngine.UI;

namespace UniTEA.Example.Todo
{
  public class TodoItem : MonoBehaviour
  {
    [SerializeField]
    Todo todo;

    public Todo Todo
    {
      get
      {
        return todo;
      }
      set
      {
        RemoveEventListener();
        todo = value;
        Render();
        RegisterEvent();
      }
    }

    [SerializeField]
    UI.Text title;

    [SerializeField]
    UI.Button delButton;

    [SerializeField]
    UI.Toggle checkBox;

    void Render()
    {
      title.text = todo.title;
      checkBox.isOn = todo.isDone;

      if (todo.isDone)
      {
        title.color = Color.gray;
      }
      else
      {
        title.color = Color.black;
      }
    }

    void RegisterEvent()
    {
      delButton.onClick.AddListener(() => TEAManager.Instance.Dispatch(new DeleteMsg(this.todo.id)));
      checkBox.onValueChanged.AddListener(_ => TEAManager.Instance.Dispatch(new DoneMsg(this.todo.id)));
    }

    void RemoveEventListener()
    {
      delButton.onClick.RemoveAllListeners();
      checkBox.onValueChanged.RemoveAllListeners();
    }

  }

}