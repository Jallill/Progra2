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
        private bool loop = true;
        private float speed = 0.005f;
        
        public Animation(string path)
        {
            LoadTextures(path);
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


    }
}
