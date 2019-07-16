using UnityEngine;

namespace UniTEA.Example.Game
{
  public struct Model
  {
    public Player player;
    public int tickCount;
    public int beat;
    public Model(Model old) => this = old;
  }

  public struct Player
  {
    public Vector3 position;
    public Vector3 scale;
    public Player(Player old) => this = old;
  }

}