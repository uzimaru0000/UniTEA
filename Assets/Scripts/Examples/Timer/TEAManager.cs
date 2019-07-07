using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TEA.Example.Timer
{
  public class TEAManager : MonoBehaviour
  {
    static TEAManager instance;
    public static TEAManager Instance
    {
      get => instance;
    }

    TEA<Model, Msg> tea;

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
      tea = new TEA<Model, Msg>(
        () => (new Model
        {
          state = TimerState.Stop
        }, Cmd<Msg>.none),
        new Updater(),
        renderer
      );
    }

    public void Commit(IMessenger<Msg> msg)
    {
      if (tea == null) return;
      tea.Commit(msg);
    }
  }
}