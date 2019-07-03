namespace TEA
{
  public interface IRenderer<Model>
    where Model : struct
  {
    void Render(Model model);
  }
}