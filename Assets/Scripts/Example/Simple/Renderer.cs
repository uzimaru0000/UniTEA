using UnityEngine;
using UnityEngine.UI;
using TEA;

namespace TEA.Example.Simple
{
  public class Renderer : MonoBehaviour, IRenderer<Model>
  {
    [SerializeField]
    Text nameLabel;

    [SerializeField]
    Text ageLabel;

    public void Render(Model model)
    {
      nameLabel.text = model.name;
      ageLabel.text = model.age.ToString();
    }
  }
}