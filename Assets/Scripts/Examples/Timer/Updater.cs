namespace UniTEA.Example.Timer
{
  class Updater : IUpdater<Model, Msg>
  {
    public (Model, Cmd<Msg>) Update(IMessenger<Msg> msg, Model model)
    {
      switch (msg)
      {
        case InputMsg inputMsg:
          return (InputUpdate(inputMsg.form, model, inputMsg.value), Cmd<Msg>.none);

        case IncrementMsg incrementMsg:
          return (Fluctuation(incrementMsg.value, model, 1), Cmd<Msg>.none);

        case DecrementMsg decrementMsg:
          return (Fluctuation(decrementMsg.value, model, -1), Cmd<Msg>.none);

        case TimerStartMsg _:
          return (new Model(model)
          {
            state = TimerState.Running
          }, Cmd<Msg>.none);

        case TimerResetMsg _:
          return (new Model
          {
            state = TimerState.Stop
          }, Cmd<Msg>.none);

        case TimerStopMsg _:
          return (new Model(model)
          {
            state = TimerState.Stop
          }, Cmd<Msg>.none);

        case TimerMsg timerMsg:
          return (new Model(model)
          {
            timer =
              model.state == TimerState.Running
                ? model.timer - timerMsg.value
                : model.timer
          }, Cmd<Msg>.none);

        default:
          return (model, Cmd<Msg>.none);
      }
    }

    Model InputUpdate(Form form, Model model, int value)
    {
      switch (form)
      {
        case Form.Hour:
          return new Model(model)
          {
            inputHour = value,
            timer = CalcTime(value, model.inputMinutes, model.inputSeconds)
          };

        case Form.Minutes:
          return new Model(model)
          {
            inputMinutes = value % 60,
            timer = CalcTime(model.inputHour, value % 60, model.inputSeconds)
          };

        case Form.Seconds:
          return new Model(model)
          {
            inputSeconds = value % 60,
            timer = CalcTime(model.inputHour, model.inputMinutes, value % 60)
          };
      }

      return model;
    }

    Model Fluctuation(Form form, Model model, int n)
    {
      switch (form)
      {
        case Form.Hour:
          if (model.inputHour + n < 0) break;
          return InputUpdate(form, model, model.inputHour + n);
        case Form.Minutes:
          if (model.inputMinutes + n < 0) break;
          return InputUpdate(form, model, model.inputMinutes + n);
        case Form.Seconds:
          if (model.inputSeconds + n < 0) break;
          return InputUpdate(form, model, model.inputSeconds + n);
      }

      return model;
    }

    float CalcTime(int hour, int minutes, int seconds)
      => hour * 60 * 60 + minutes * 60 + seconds;
  }
}