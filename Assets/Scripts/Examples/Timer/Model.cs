namespace TEA.Example.Timer
{
  struct Model
  {
    public float timer;
    public TimerState state;

    public int inputHour;
    public int inputMinutes;
    public int inputSeconds;
    public Model(Model old) => this = old;
  }

  enum TimerState
  {
    Running,
    Stop
  }
}