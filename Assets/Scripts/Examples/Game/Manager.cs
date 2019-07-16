using UnityEngine;

namespace UniTEA.Example.Game
{
  public class Manager : MonoBehaviour
  {
    UniTEA<Model, Msg> _teaInstance;

    UniTEA<Model, Msg> teaInstance
    {
      get
      {
        if (_teaInstance == null)
        {
          _teaInstance = new UniTEA<Model, Msg>(
            () => (new Model
            {
              player = new Player
              {
                position = new Vector3(0, 0.5f, 0),
                scale = Vector3.one
              },
              tickCount = 0,
              beat = 5
            }, Cmd<Msg>.none),
            new Updater(),
            renderer
          );
        }

        return _teaInstance;
      }
    }

    [SerializeField]
    new Renderer renderer;

    public void Dispatch(IMessenger<Msg> msg)
    {
      teaInstance.Dispatch(msg);
    }

  }
}