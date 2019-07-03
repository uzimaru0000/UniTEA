namespace TEA
{
  public interface IUpdater<Model, Msg>
    where Model : struct
    where Msg : struct
  {
    Model Update(IMessenger<Msg> msg, Model model);
  }
}