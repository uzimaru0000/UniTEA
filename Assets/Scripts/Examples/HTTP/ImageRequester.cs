using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace TEA.Example.HTTP
{
  class ImageRequester
  {

    int width;
    int height;
    System.Func<Texture, IMessenger<Msg>> msg;

    string url
    {
      get => string.Format("http://lorempixel.com/{0}/{1}/", width, height);
    }

    public ImageRequester(int width, int height, System.Func<Texture, IMessenger<Msg>> msg)
    {
      this.width = width;
      this.height = height;
      this.msg = msg;
    }

    async Task<IMessenger<Msg>> CreateRequest()
    {
      UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);
      await req.SendWebRequest();
      return msg.Invoke(((DownloadHandlerTexture)req.downloadHandler).texture);
    }

    public Cmd<Msg> ToCmd() => new Cmd<Msg>(CreateRequest());
  }
}