using UniTEA.Utils;
using UnityEngine;

namespace UniTEA.Example.HTTP
{
  public class GetImageMsg : OneValueMsg<Msg, Texture>
  {
    public override Msg GetMessage() => Msg.GetImage;
    public GetImageMsg(Texture value) : base(value) { }
  }
}