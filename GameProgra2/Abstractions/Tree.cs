using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Tree : IBaseMethods
    {

        Node core;
        string basePath = "Textures/NodeCircle";

        public Tree(int value)
        {

            
            core.AddNode(value, core);
            //nodes.Add(new Animation(basePath, 1f));
            
        }

        public void Input()
        {

        }

        public void Update()
        {

        }

        public void Render()
        {

            //nodes.ForEach(node => node.RenderNextFrame(, 100));

        }

    }
}
