namespace TEA.Utils
{
  public abstract class OneValueMsg<T, U> : IMessenger<T>
    where T : struct
  {
    public abstract T GetMessage();

    public U value
    {
      get;
    }

    public OneValueMsg(U value)
    {
      this.value = value;
    }
  }
}