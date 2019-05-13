using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GameObject : Collider
    {
        protected Dictionary<int, Animation> animations = new Dictionary<int, Animation>();
        protected Animation currentAnimation;

        public GameObject(float x, float y, float sizeX, float sizeY, bool isCollisionable = false, bool isCircle = false) : base(x, y, sizeX, sizeY, isCollisionable, isCircle)
        {
            
        }
    }
}