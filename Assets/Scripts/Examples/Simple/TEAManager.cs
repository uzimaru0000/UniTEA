using UnityEngine;
using TEA;
using System.Threading.Tasks;

namespace TEA.Example.Simple
{
  public class TEAManager : MonoBehaviour
  {
    [SerializeField]
    new Renderer renderer;

    TEA<Model, Msg> tea
    {
      get;
      set;
    }

    void Start()
    {
      tea = new TEA<Model, Msg>(() => (new Model(), Cmd<Msg>.none), new Updater(), renderer);
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
        case NameChanger changer:
          return (new Model()
          {
            age = model.age,
            name = changer.value
          }, Cmd<Msg>.none);

        case AgeChanger changer:
          return (new Model()
          {
            age = changer.value,
            name = model.name
          }, Cmd<Msg>.none);
      }

      return (model, Cmd<Msg>.none);
    }
  }
}