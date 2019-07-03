using TEA;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace TEA.Example.Todo
{
  class Updater : IUpdater<Model, Msg>
  {
    Counter idCounter;

    public Updater()
    {
      idCounter = new Counter();
    }

    public Model Update(IMessenger<Msg> msg, Model model)
    {
      UnityEngine.Debug.Log(msg);
      switch (msg)
      {
        case InputMsg inputMsg:
          return new Model
          {
            input = inputMsg.value,
            todoList = model.todoList
          };

        case AddTodoMsg addTodoMsg:
          if (model.input.Length == 0) break;

          var todo = new Todo
          {
            id = idCounter.Count(),
            title = model.input,
            isDone = false
          };

          return new Model
          {
            input = "",
            todoList = model.todoList.Add(todo)
          };

        case DoneMsg doneMsg:
          return new Model
          {
            input = model.input,
            todoList = model.todoList.Select(x =>
            {
              if (x.id == doneMsg.id)
              {
                x.isDone = !x.isDone;
              }
              return x;
            }).ToImmutableList()
          };

        case DeleteMsg deleteMsg:
          return new Model
          {
            input = model.input,
            todoList = model.todoList.Where(x => x.id != deleteMsg.id).ToImmutableList()
          };
      }
      return model;
    }

    class Counter
    {
      int counter;

      public Counter(int init = 0)
      {
        counter = init;
      }

      public int Count()
      {
        return counter++;
      }
    }
  }
}