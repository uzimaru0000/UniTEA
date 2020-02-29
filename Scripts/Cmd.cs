using System;

namespace UniTEA
{
    public struct Cmd<T> where T : struct
    {
        public static Cmd<T> none = new Cmd<T>(_ => { });

        public static Cmd<T> batch(Cmd<T>[] cmds)
        {
            return new Cmd<T>(d =>
            {
                foreach (Cmd<T> cmd in cmds)
                {
                    cmd.exec(d);
                }
            });
        }

        Action<Dispatcher<T>> task;

        public void exec(Dispatcher<T> d) => this.task(d);

        public Cmd(Action<Dispatcher<T>> task)
        {
            this.task = task;
        }
    }
}