using UnityEngine;

namespace UniTEA.Example.Game
{
  public class Updater : IUpdater<Model, Msg>
  {
    public (Model, Cmd<Msg>) Update(IMessenger<Msg> msg, Model model)
    {
      switch (msg)
      {
        case TickMsg _:
          var newPlayer = new Player(model.player)
          {
            scale = (model.tickCount + 1) % model.beat == 0
                      ? Vector3.one * 1.5f
                      : Vector3.Lerp(model.player.scale, Vector3.one, 1.0f / model.beat)
          };
          return (new Model(model)
          {
            tickCount = model.tickCount + 1,
            player = newPlayer
          }, Cmd<Msg>.none);

        case MoveMsg moveMsg:
          return (new Model(model)
          {
            player = new Player(model.player)
            {
              position = Beeting(model)
                          ? model.player.position + MoveDelta(moveMsg.value)
                          : model.player.position
            }
          }, Cmd<Msg>.none);

        default:
          return (model, Cmd<Msg>.none);
      }
    }

    bool Beeting(Model model) => model.tickCount % model.beat == 0;

    Vector3 MoveDelta(Direction dir)
    {
      switch (dir)
      {
        case Direction.Forward:
          return Vector3.forward;
        case Direction.Backward:
          return Vector3.back;
        case Direction.Left:
          return Vector3.left;
        case Direction.Right:
          return Vector3.right;
        default:
          return Vector3.zero;
      }
    }
  }
}