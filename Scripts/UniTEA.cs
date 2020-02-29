using System.Threading.Tasks;

namespace UniTEA
{
    public class UniTEA<T, U>
      where T : struct
      where U : struct
    {

        IUpdater<T, U> updater;
        IRenderer<T, U> renderer;
        T model;

        public UniTEA(
          System.Func<(T, Cmd<U>)> init,
          IUpdater<T, U> updater,
          IRenderer<T, U> renderer
        )
        {
            this.updater = updater;
            this.renderer = renderer;
            var (initModel, cmd) = init.Invoke();
            this.model = initModel;
            this.renderer.Init(Dispatch);
            cmd.exec(Dispatch);
            renderer.Render(this.model);
        }

        public void Dispatch(IMessenger<U> msg)
        {
            var (newModel, cmd) = this.updater.Update(msg, model);
            if (!Equals(newModel, model))
            {
                this.renderer.Render(newModel);
            }
            this.model = newModel;
            cmd.exec(Dispatch);
        }

    }
}