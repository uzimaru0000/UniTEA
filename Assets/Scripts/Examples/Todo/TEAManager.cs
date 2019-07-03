using UnityEngine;
using System.Collections.Immutable;

namespace TEA.Example.Todo
{

  public class TEAManager : MonoBehaviour
  {
    static TEAManager _instance;

    public static TEAManager Instance
    {
      get
      {
        return _instance;
      }
    }

    [SerializeField]
    new Renderer renderer;

    TEA<Model, Msg> tea;

    void Awake()
    {
      if (_instance != null) Destroy(gameObject);
      _instance = this;
    }

    void Start()
    {
      tea = new TEA<Model, Msg>(
        () => new Model
        {
          input = "",
          todoList = ImmutableList.Create<Todo>()
        }, new Updater(), renderer);
    }

    void Update()
    {
      tea.Update();
    }

    public void Commit(IMessenger<Msg> msg)
    {
      tea.Commit(msg);
    }
  }

}