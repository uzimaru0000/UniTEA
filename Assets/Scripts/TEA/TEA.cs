using System.Collections.Generic;

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

    public TEA(System.Func<Model> init, IUpdater<Model, Msg> updater, IRenderer<Model> renderer)
    {
      this.updater = updater;
      this.renderer = renderer;
      queue = new Queue<IMessenger<Msg>>();
      model = init.Invoke();

      renderer.Render(model);
    }

    public void Update()
    {
      while (queue.Count > 0)
      {
        var msg = queue.Dequeue();
        model = updater.Update(msg, model);
      }
      renderer.Render(model);
    }

    public void Commit(IMessenger<Msg> msg)
    {
      queue.Enqueue(msg);
    }

  }
}