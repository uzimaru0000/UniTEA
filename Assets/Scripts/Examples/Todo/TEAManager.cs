using UnityEngine;
using System.Collections.Immutable;

namespace UniTEA.Example.Todo
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

    UniTEA<Model, Msg> tea;

    void Awake()
    {
      if (_instance != null) Destroy(gameObject);
      _instance = this;
    }

    void Start()
    {
      tea = new UniTEA<Model, Msg>(
        () => (new Model
        {
          input = "",
          todoList = ImmutableList.Create<Todo>()
        }, Cmd<Msg>.none), new Updater(), renderer);
    }

    public void Dispatch(IMessenger<Msg> msg)
    {
      tea.Dispatch(msg);
    }
  }

}