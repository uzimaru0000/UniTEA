using UnityEngine;

namespace UniTEA.Example.HTTP
{
  public class TEAManager : MonoBehaviour
  {

    UniTEA<Model, Msg> tea;

    [SerializeField]
    new Renderer renderer;

    void Start()
    {
      var request = new ImageRequester(320, 320, x => new GetImageMsg(x));
      tea = new UniTEA<Model, Msg>(() => (new Model
      {
        texture = null,
        width = 320,
        height = 320
      }, request.ToCmd()), new Updater(), renderer);
    }

    public void Dispatch(IMessenger<Msg> msg)
    {
      if (tea == null) return;
      tea.Dispatch(msg);
    }

  }
}