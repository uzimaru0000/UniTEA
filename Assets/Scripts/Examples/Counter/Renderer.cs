using UnityEngine;

namespace UniTEA.Example.Counter
{
  class Renderer : MonoBehaviour, IRenderer<Model>
  {
    [SerializeField]
    UnityEngine.UI.Text counterLabel;

    public void Render(Model model)
    {
      counterLabel.text = model.counter.ToString();
    }
  }
}