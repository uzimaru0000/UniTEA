using System.Collections.Immutable;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TEA;

namespace TEA.Example.Todo
{

  public class Renderer : MonoBehaviour, IRenderer<Model>
  {
    [SerializeField]
    TodoItem todoPrefab;

    [SerializeField]
    Transform list;

    [SerializeField]
    InputField input;

    public void Render(Model model)
    {
      input.text = model.input;
      CreateListItem(model.todoList);
    }

    void DestroyListItem(int removeCount)
    {
      foreach (Transform child in list)
      {
        if (removeCount <= 0) break;
        Destroy(child.gameObject);
        removeCount--;
      }
    }

    void InstanceListItem(int instanceCount)
    {
      for (var i = 0; i < instanceCount; i++)
      {
        Instantiate(todoPrefab, list);
      }
    }

    void ListMapping(ImmutableList<Todo> todoList)
    {
      var tuples = list.GetComponentsInChildren<TodoItem>()
                       .Zip(todoList, (x, y) => (x, y));

      foreach (var (x, y) in tuples)
      {
        x.Todo = y;
      }
    }

    void CreateListItem(ImmutableList<Todo> todoList)
    {
      if (todoList.Count < list.childCount)
      {
        DestroyListItem(list.childCount - todoList.Count);
      }
      else if (todoList.Count > list.childCount)
      {
        InstanceListItem(todoList.Count - list.childCount);
      }
      ListMapping(todoList);
    }

  }
}