using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        const int MS_PER_FRAME = 1000 / 60;

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

        static void input()
        {

        }

        static void update()
        {

        }

        static void render()
        {

        }

        static void setUp()
        {
            Engine.Initialize("Parcial", 800, 600, false);

            startDate = DateTime.Now;
        }

        static float GetCurrentTime()
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