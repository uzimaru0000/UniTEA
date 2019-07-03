using UnityEngine;
using TEA;

namespace TEA.Example.Counter
{
  public class TEAManager : MonoBehaviour
  {
    [SerializeField]
    new Renderer renderer;

    TEA<Model, Msg> tea;

    void Start()
    {
      tea = new TEA<Model, Msg>(() => new Model() { counter = 0 }, new Updater(), renderer);
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

  class Updater : IUpdater<Model, Msg>
  {
    public Model Update(IMessenger<Msg> msg, Model model)
    {
      switch (msg)
      {
        case IncrementMsg increment:
          return new Model()
          {
            counter = model.counter + 1
          };

        case DecrementMsg decrement:
          return new Model()
          {
            counter = model.counter - 1
          };
      }

      return new Model();
    }
  }
}