using UnityEngine;
using UniTEA;
using System.Threading.Tasks;

namespace UniTEA.Example.Simple
{
  public class TEAManager : MonoBehaviour
  {
    [SerializeField]
    new Renderer renderer;

    UniTEA<Model, Msg> tea
    {
      get;
      set;
    }

    void Start()
    {
      tea = new UniTEA<Model, Msg>(() => (new Model(), Cmd<Msg>.none), new Updater(), renderer);
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