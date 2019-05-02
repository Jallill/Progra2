using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Crane
    {
        private float x;
        private float y;
        private float offsetX;
        private float offsetY;

        private Animation derecha; //test
        private enum AnimationState { right }
        private AnimationState state;

        public Crane(float x, float y)
        {
            this.x = x;
            this.y = y;
            offsetX = 26;
            offsetY = 23;
            derecha = new Animation("Textures/Derecha",0.05f);
            state = AnimationState.right;
        }

        public void Render()
        {
            switch (state)
            {
                case AnimationState.right:
                    derecha.RenderNextFrame(x, y);
                    break;
            }
            
        }
    }
}
