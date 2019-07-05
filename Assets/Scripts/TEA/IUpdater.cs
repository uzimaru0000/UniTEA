using System.Threading.Tasks;

namespace TEA
{
  public interface IUpdater<Model, Msg>
    where Model : struct
    where Msg : struct
  {
    (Model, Cmd<Msg>) Update(IMessenger<Msg> msg, Model model);
  }
}