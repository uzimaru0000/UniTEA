using UnityEngine;
using TEA;
using System.Threading.Tasks;

namespace TEA.Example.Counter
{
  public class TEAManager : MonoBehaviour
  {
    [SerializeField]
    new Renderer renderer;

    TEA<Model, Msg> tea;

    void Start()
    {
      tea = new TEA<Model, Msg>(() => (new Model() { counter = 0 }, Cmd<Msg>.none), new Updater(), renderer);
    }

    public void Commit(IMessenger<Msg> msg)
    {
      tea.Commit(msg);
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