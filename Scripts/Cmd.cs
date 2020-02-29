using System.Threading.Tasks;

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

        System.Action<System.Action<IMessenger<T>>> task;

        public void exec(System.Action<IMessenger<T>> d) => this.task(d);

        public Cmd(System.Action<System.Action<IMessenger<T>>> task)
        {
            this.task = task;
        }
    }
}