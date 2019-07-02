using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        renderer.Render(model);
      }
    }

    public void Commit(IMessenger<Msg> msg)
    {
      queue.Enqueue(msg);
    }

  }


  public interface IMessenger<T> where T : struct
  {
    T GetMessage();
  }

  public interface IUpdater<Model, Msg>
    where Model : struct
    where Msg : struct
  {
    Model Update(IMessenger<Msg> msg, Model model);
  }

  public interface IRenderer<Model>
    where Model : struct
  {
    void Render(Model model);
  }

}