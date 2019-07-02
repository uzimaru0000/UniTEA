using UnityEngine;
using TEA;

namespace TEA.Example.Simple
{
  public class TEAManager : MonoBehaviour
  {
    [SerializeField]
    new Renderer renderer;

    public TEA<Model, Msg> tea
    {
      get;
      private set;
    }

    void Start()
    {
      tea = new TEA<Model, Msg>(() => new Model(), new Updater(), renderer);
    }

    void Update()
    {
      tea.Update();
    }
  }

  class Updater : IUpdater<Model, Msg>
  {
    public Model Update(IMessenger<Msg> msg, Model model)
    {
      switch (msg)
      {
        case NameChanger changer:
          return new Model()
          {
            age = model.age,
            name = changer.name
          };

        case AgeChanger changer:
          return new Model()
          {
            age = changer.age,
            name = model.name
          };
      }

      return new Model();
    }
  }
}