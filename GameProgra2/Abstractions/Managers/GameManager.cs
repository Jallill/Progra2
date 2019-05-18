using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Managers
{

    public class GameManager
    {

        private static GameManager instance = new GameManager();

        public static GameManager Instance {
            get {
                return instance;
            }
        }

        public delegate void input();
        public delegate void update();
        public delegate void render();

        public input Input { get; private set; }
        public update Update { get; private set; }
        public render Render { get; private set; }

        public void SetState<T>(T t) where T : IBaseMethods
        {
            Input = new input(t.Input);
            Update = new update(t.Update);
            Render = new render(t.Render);
        }

    }
}
