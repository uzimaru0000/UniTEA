using TEA.Utils;

namespace TEA.Example.Simple
{
  public enum Msg
  {
    ChangeName,
    ChangeAge
  }

  class NameChanger : OneValueMsg<Msg, string>
  {
    public override Msg GetMessage() => Msg.ChangeName;
    public NameChanger(string name) : base(name) { }
  }

  class AgeChanger : OneValueMsg<Msg, int>
  {
    public override Msg GetMessage() => Msg.ChangeAge;
    public AgeChanger(int age) : base(age) { }
  }
}