namespace TEA
{
  public interface IMessenger<T> where T : struct
  {
    T GetMessage();
  }
}