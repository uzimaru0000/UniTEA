using UnityEngine;
using UI = UnityEngine.UI;

namespace UniTEA.Example.HTTP
{
  public class Renderer : MonoBehaviour, IRenderer<Model>
  {
    [SerializeField]
    UI.InputField widthInput;

    [SerializeField]
    UI.InputField heightInput;

    [SerializeField]
    UI.RawImage image;

    public void Render(Model model)
    {
      widthInput.text = model.width.ToString();
      heightInput.text = model.height.ToString();
      image.texture = model.texture;
      image.SetNativeSize();
    }
  }
}