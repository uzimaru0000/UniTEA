namespace UniTEA
{
  public interface IRenderer<T>
    where T : struct
  {
    void Render(T model);
  }
}