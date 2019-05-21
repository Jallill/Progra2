using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{

    public class Animation
    {
        public string name { get; private set; }

        private bool loop;

        private float speed = 0.05f;
        private float lastFrame;

        private int nextFrame = 0;

        private List<Texture> frames = new List<Texture>();
        private Texture actualFrame;

        public Animation(string path, float speed)
        {
            LoadTextures(path);
            actualFrame = frames.First();

            this.speed = speed;
        }

        private void LoadTextures(string path)
        {
            DirectoryInfo myDir = new DirectoryInfo(path);
            name = myDir.Name;
            if (myDir.GetFiles().Length > 1)
            {
                loop = true;

                foreach (FileInfo file in myDir.GetFiles())
                {
                    frames.Add(Engine.GetTexture(file.FullName));
                }

            }
            else
            {
                frames.Add(Engine.GetTexture(myDir.GetFiles()[0].FullName));
                actualFrame = frames[0];
                loop = false;
            }


        }

        public void RenderNextFrame(float x, float y, float angle = 0)
        {
            if (loop)
            {

                if (Program.GetCurrentTime() / 1000f > lastFrame + speed)
                {
                    nextFrame++;
                    if (nextFrame >= frames.Count())
                    {
                        nextFrame = 0;
                    }

                    actualFrame = frames[nextFrame];
                    lastFrame = Program.GetCurrentTime() / 1000f;
                }
            }
            Engine.Draw(actualFrame, x, y, 1, 1, angle, actualFrame.Width/2, actualFrame.Height/2);
        }

    }
}
