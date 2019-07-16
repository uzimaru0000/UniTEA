using UnityEngine;
using UniTEA;
using System.Threading.Tasks;

namespace UniTEA.Example.Counter
{
  public class TEAManager : MonoBehaviour
  {
    [SerializeField]
    new Renderer renderer;

    UniTEA<Model, Msg> tea;

    void Start()
    {
      tea = new UniTEA<Model, Msg>(() => (new Model() { counter = 0 }, Cmd<Msg>.none), new Updater(), renderer);
    }

    public void Dispatch(IMessenger<Msg> msg)
    {
      tea.Dispatch(msg);
    }
  }

  class Updater : IUpdater<Model, Msg>
  {
    public (Model, Cmd<Msg>) Update(IMessenger<Msg> msg, Model model)
    {
      switch (msg)
      {
        case IncrementMsg increment:
          return (new Model()
          {
            counter = model.counter + 1
          }, Cmd<Msg>.none);

        case DecrementMsg decrement:
          return (new Model()
          {
            counter = model.counter - 1
          }, Cmd<Msg>.none);
      }

      return (model, Cmd<Msg>.none);
    }
  }
}