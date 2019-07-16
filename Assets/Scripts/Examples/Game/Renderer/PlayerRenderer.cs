using UnityEngine;

namespace UniTEA.Example.Game
{
  public class PlayerRenderer : MonoBehaviour
  {
    Player _player;

    public Player player
    {
      get
      {
        return _player;
      }
      set
      {
        _player = value;
        Render();
      }
    }

    void Render()
    {
      transform.position = player.position;
      transform.localScale = player.scale;
    }

    void Update()
    {
    }

  }
}