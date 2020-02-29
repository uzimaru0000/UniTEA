using System.Threading.Tasks;

namespace UniTEA
{
    public delegate void Dispatcher<T>(IMessenger<T> msg) where T : struct;

    public class UniTEA<T, U>
      where T : struct
      where U : struct
    {

        IUpdater<T, U> updater;
        IRenderer<T, U> renderer;
        System.Func<T, Sub<IMessenger<U>>> subscription;
        T model;

        Sub<IMessenger<U>> currentSubscription;

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

        public UniTEA(
          System.Func<(T, Cmd<U>)> init,
          IUpdater<T, U> updater,
          IRenderer<T, U> renderer,
          System.Func<T, Sub<IMessenger<U>>> subscription
        )
        {
            this.updater = updater;
            this.renderer = renderer;
            this.subscription = subscription;

            var (initModel, cmd) = init.Invoke();
            this.model = initModel;

            cmd.exec(Dispatch);

            this.renderer.Init(Dispatch);
            renderer.Render(this.model);

            UpdateSubscription();
        }

        public void Dispatch(IMessenger<U> msg)
        {
            var (newModel, cmd) = this.updater.Update(msg, model);
            if (!Equals(newModel, model))
            {
                this.renderer.Render(newModel);
                this.model = newModel;
            }
            cmd.exec(Dispatch);
            UpdateSubscription();
        }

        void UpdateSubscription()
        {
            if (this.currentSubscription != null)
            {
                this.currentSubscription.OnWatch -= Dispatch;
            }
            this.currentSubscription = this.subscription(this.model);
            this.currentSubscription.OnWatch += Dispatch;
        }
    }
}