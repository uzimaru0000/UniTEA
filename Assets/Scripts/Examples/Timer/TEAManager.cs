using UnityEngine;

namespace UniTEA.Example.Timer
{
  public class TEAManager : MonoBehaviour
  {
    static TEAManager instance;
    public static TEAManager Instance
    {
      get => instance;
    }

    UniTEA<Model, Msg> tea;

    [SerializeField]
    new Renderer renderer;

    void Awake()
    {
      if (instance != null)
      {
        Destroy(gameObject);
      }
      instance = this;
    }

    void Start()
    {
      tea = new UniTEA<Model, Msg>(
        () => (new Model
        {
          state = TimerState.Stop
        }, Cmd<Msg>.none),
        new Updater(),
        renderer
      );
    }

    public void Dispatch(IMessenger<Msg> msg)
    {
      if (tea == null) return;
      tea.Dispatch(msg);
    }
  }
}