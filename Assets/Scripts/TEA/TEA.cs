using System.Collections.Generic;
using System.Threading.Tasks;

namespace TEA
{
  public class TEA<Model, Msg>
    where Model : struct
    where Msg : struct
  {

    IUpdater<Model, Msg> updater;

    IRenderer<Model> renderer;

    Queue<IMessenger<Msg>> queue;

    Model model;

    public TEA(
      System.Func<(Model, Cmd<Msg>)> init,
      IUpdater<Model, Msg> updater,
      IRenderer<Model> renderer
    )
    {
      this.updater = updater;
      this.renderer = renderer;
      queue = new Queue<IMessenger<Msg>>();
      var (initModel, cmd) = init.Invoke();
      this.model = initModel;
      _ = ExecTask(cmd);

      renderer.Render(this.model);
    }

    public void Update()
    {
      while (queue.Count > 0)
      {
        var msg = queue.Dequeue();
        var (newModel, cmd) = updater.Update(msg, model);
        model = newModel;
        _ = ExecTask(cmd);
      }
      renderer.Render(model);
    }

    async Task ExecTask(Cmd<Msg> cmd)
    {
      if (cmd == Cmd<Msg>.NoOp) return;
      IMessenger<Msg> msg = await cmd.Preform();
      Commit(msg);
    }

    public void Commit(IMessenger<Msg> msg)
    {
      queue.Enqueue(msg);
    }

  }
}