using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    class Animation
    {
        private List<Texture> frames = new List<Texture>();
        private bool loop;
        private float speed = 0.05f;
        private float lastFrame;
        private int nextFrame = 0;
        private Texture actualFrame;
        
        public Animation(string path, float speed, bool loop)
        {
            LoadTextures(path);
            actualFrame = frames.First();

            this.speed = speed;
            this.loop = loop;
        }

        private void LoadTextures(string path)
        {

            DirectoryInfo myDir = new DirectoryInfo(path);
            int count = myDir.GetFiles().Length;
            foreach(FileInfo file in myDir.GetFiles())
            {
                frames.Add(Engine.GetTexture(file.FullName));
            }

        }

        public void RenderNextFrame(float x, float y)
        {
            if (loop)
            { 

                if (Program.GetCurrentTime() / 1000f > lastFrame + speed)
                {
                    nextFrame++;
                    if(nextFrame >= frames.Count())
                    {
                        nextFrame = 0;
                    }

                    actualFrame = frames[nextFrame];
                    lastFrame = Program.GetCurrentTime() / 1000f;
                }

            }
            else
            {
                actualFrame = frames[0];
            }
            Engine.Draw(actualFrame, x, y, 1, 1, 0, actualFrame.Width / 2, actualFrame.Height / 2);
        }

    }
}
