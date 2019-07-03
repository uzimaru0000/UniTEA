using TEA;

namespace TEA.Example.Simple
{
  public enum Msg
  {
    ChangeName,
    ChangeAge
  }

  class NameChanger : IMessenger<Msg>
  {
    public string name
    {
      get;
      private set;
    }

    public NameChanger(string name)
    {
      this.name = name;
    }

    public Msg GetMessage()
    {
      return Msg.ChangeName;
    }
  }

  class AgeChanger : IMessenger<Msg>
  {
    public int age
    {
      get;
      private set;
    }

    public AgeChanger(int age)
    {
      this.age = age;
    }

    public Msg GetMessage()
    {
      return Msg.ChangeAge;
    }
  }
}