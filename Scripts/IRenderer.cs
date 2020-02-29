namespace UniTEA
{
    public interface IRenderer<T, U>
      where T : struct
      where U : struct
    {
        void Init(Dispatcher<U> dispatcher);
        void Render(T model);
    }
}