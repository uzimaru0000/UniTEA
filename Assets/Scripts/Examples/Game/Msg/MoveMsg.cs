using UniTEA.Utils;

namespace UniTEA.Example.Game
{
  public class MoveMsg : OneValueMsg<Msg, Direction>
  {
    public override Msg GetMessage() => Msg.Move;

    public MoveMsg(Direction value) : base(value) { }
  }

  public enum Direction
  {
    Forward,
    Backward,
    Left,
    Right
  }

}