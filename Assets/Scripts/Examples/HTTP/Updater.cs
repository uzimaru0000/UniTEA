using System.Threading.Tasks;
using UnityEngine.Networking;

namespace TEA.Example.HTTP
{
  class Updater : IUpdater<Model, Msg>
  {
    public (Model, Cmd<Msg>) Update(IMessenger<Msg> msg, Model model)
    {
      switch (msg)
      {
        case InputWidthMsg inputMsg:
          return (new Model
          {
            texture = model.texture,
            width = inputMsg.value,
            height = model.height
          }, Cmd<Msg>.none);

        case InputHeightMsg inputMsg:
          return (new Model
          {
            texture = model.texture,
            height = inputMsg.value,
            width = model.width
          }, Cmd<Msg>.none);

        case RequestMsg _:
          var request = new ImageRequester(model.width, model.height, x => new GetImageMsg(x));
          return (model, request.ToCmd());

        case GetImageMsg getImageMsg:
          return (new Model
          {
            texture = getImageMsg.value,
            width = model.width,
            height = model.height
          }, Cmd<Msg>.none);
      }
      return (model, Cmd<Msg>.none);
    }
  }

}