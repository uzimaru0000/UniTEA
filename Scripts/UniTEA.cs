using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace UniTEA
{
  public class UniTEA<T, U>
    where T : struct
    where U : struct
  {

    IUpdater<T, U> updater;
    IRenderer<T> renderer;
    Queue<IMessenger<U>> queue;
    T model;

    public UniTEA(
      System.Func<(T, Cmd<U>)> init,
      IUpdater<T, U> updater,
      IRenderer<T> renderer
    )
    {
      this.updater = updater;
      this.renderer = renderer;
      queue = new Queue<IMessenger<U>>();
      var (initModel, cmd) = init.Invoke();
      this.model = initModel;
      _ = ExecTask(cmd);

      renderer.Render(this.model);
    }

    async Task ExecTask(Cmd<U> cmd)
    {
      if (cmd == Cmd<U>.none) return;
      IMessenger<U> msg = await cmd.Preform();
      Dispatch(msg);
    }

    public void Dispatch(IMessenger<U> msg)
    {
      var (newModel, cmd) = updater.Update(msg, model);
      model = newModel;
      _ = ExecTask(cmd);
      renderer.Render(model);
    }

  }
}