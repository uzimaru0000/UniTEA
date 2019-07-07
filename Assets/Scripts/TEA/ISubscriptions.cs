namespace TEA
{
  public interface ISubscriptions<Model, Msg>
    where Model : struct
    where Msg : struct
  {
    IMessenger<Msg> Subscriptions(Model model);
  }
}