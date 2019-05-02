using System;
using System.Collections.Generic;

namespace Engine
{
    public class Program
    {
        const int MS_PER_FRAME = 1000 / 60;


        public enum States { MainMenu, MainGame, Exit }
        public static List<Int32> scores;
        public static States currentState = States.MainMenu;

        static bool loop = true;
        static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;
        static DateTime startDate;

        static void Main(string[] args)
        {

            int sleepTime;

            setUp();

            while (loop)
            {
                float start = GetCurrentTime();
                calculateDeltaTime();

                input();
                update();
                render();

                sleepTime = Convert.ToInt32(start + MS_PER_FRAME - GetCurrentTime());

                if (sleepTime > 0)
                {
                    System.Threading.Thread.Sleep(sleepTime);
                }
            }
        }

        static void setUp()
        {
            Engine.Initialize("Progra2", 800, 600, false);

            Node core = new Node(0);
            core.addNode(3, core);
            core.addNode(5, core);
            core.addNode(2, core);

            core.searchNode(2, core);
            core.searchNode(9, core);

            startDate = DateTime.Now;
        }


        static void input()
        {
            switch (currentState)
            {
            }

        }

        static void update()
        {
            switch (currentState)
            {
                case (States.Exit):
                    Environment.Exit(1);
                    break;
            }

        }

        static void render()
        {
            Engine.Clear(0, 0, 0);
            switch (currentState)
            {
            }
            Engine.Show();
        }

        public static float GetCurrentTime()
        {
            TimeSpan diffStart = DateTime.Now.Subtract(startDate);
            return (float)(diffStart.TotalMilliseconds);
        }

        static void calculateDeltaTime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }
    }
}