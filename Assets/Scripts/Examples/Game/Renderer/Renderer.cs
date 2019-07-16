using UnityEngine;

namespace UniTEA.Example.Game
{
  public class Renderer : MonoBehaviour, IRenderer<Model>
  {

    [SerializeField]
    PlayerRenderer playerRenderer;

    public void Render(Model model)
    {
      playerRenderer.player = model.player;
    }
  }
}