using System.Threading.Tasks;

namespace TEA
{
  public struct Cmd<Msg> where Msg : struct
  {

    public static Cmd<Msg> NoOp = new Cmd<Msg>(null);

    Task<IMessenger<Msg>> task
    {
      get;
      set;
    }

    public Cmd(Task<IMessenger<Msg>> task)
    {
      this.task = task;
    }

    public async Task<IMessenger<Msg>> Preform()
    {
      IMessenger<Msg> msg = await task;
      return msg;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || !(obj is Cmd<Msg>))
      {
        return false;
      }
      return (Cmd<Msg>)obj == this;
    }

    public override int GetHashCode()
    {
      return task.GetHashCode();
    }

    public static bool operator ==(Cmd<Msg> msg1, Cmd<Msg> msg2)
    {
      if (msg1.task == null || msg2.task == null)
      {
        return msg1.task == msg2.task;
      }

      return msg1.task.Id == msg2.task.Id;
    }

    public static bool operator !=(Cmd<Msg> msg1, Cmd<Msg> msg2)
    {
      return !(msg1 == msg2);
    }

  }
}