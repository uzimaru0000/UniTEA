using UnityEngine;

namespace TEA.Example.HTTP
{
  public class TEAManager : MonoBehaviour
  {

    TEA<Model, Msg> tea;

    [SerializeField]
    new Renderer renderer;

    void Start()
    {
      var request = new ImageRequester(320, 320, x => new GetImageMsg(x));
      tea = new TEA<Model, Msg>(() => (new Model
      {
        texture = null,
        width = 320,
        height = 320
      }, request.ToCmd()), new Updater(), renderer);
    }

    void Update()
    {
    }

    public void Commit(IMessenger<Msg> msg)
    {
      if (tea == null) return;
      tea.Commit(msg);
    }

  }
}