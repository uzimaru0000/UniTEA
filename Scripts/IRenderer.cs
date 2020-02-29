namespace UniTEA
{
    public interface IRenderer<T, U>
      where T : struct
      where U : struct
    {
        void Init(System.Action<IMessenger<U>> dispatcher);
        void Render(T model);
    }
}