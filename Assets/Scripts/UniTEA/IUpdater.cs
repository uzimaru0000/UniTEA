using System.Threading.Tasks;

namespace UniTEA
{
  public interface IUpdater<T, U>
    where T : struct
    where U : struct
  {
    (T, Cmd<U>) Update(IMessenger<U> msg, T model);
  }
}