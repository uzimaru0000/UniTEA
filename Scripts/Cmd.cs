using System.Threading.Tasks;

namespace UniTEA
{
  public struct Cmd<T> where T : struct
  {

    public static Cmd<T> none = new Cmd<T>(null);

    Task<IMessenger<T>> task
    {
      get;
      set;
    }

    public Cmd(Task<IMessenger<T>> task)
    {
      this.task = task;
    }

    public async Task<IMessenger<T>> Preform()
    {
      IMessenger<T> msg = await task;
      return msg;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || !(obj is Cmd<T>))
      {
        return false;
      }
      return (Cmd<T>)obj == this;
    }

    public override int GetHashCode()
    {
      return task.GetHashCode();
    }

    public static bool operator ==(Cmd<T> msg1, Cmd<T> msg2)
    {
      if (msg1.task == null || msg2.task == null)
      {
        return msg1.task == msg2.task;
      }

      return msg1.task.Id == msg2.task.Id;
    }

    public static bool operator !=(Cmd<T> msg1, Cmd<T> msg2)
    {
      return !(msg1 == msg2);
    }

  }
}