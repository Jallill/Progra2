using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Managers;
using static Game.Utils.Enums;

namespace Game
{
    public class Tile : GameObject
    {
        const float SPEED = 0.1f;
        
        public TileWallRol rol { get; private set; }
        public float size { get; private set; }

        Animation animation;

        float renderX;
        float renderY;
        

        public Tile(float x, float y, float size, string animationFloder, TileWallRol rol) : base(x, y, size, size, true)
        {

            this.rol = rol;
            this.size = size;

            renderX = x + size * 0.5f;
            renderY = y + size * 0.5f;
            animation = new Animation(animationFloder, SPEED);
        }

        public void Render()
        {
            animation.RenderNextFrame(renderX, renderY);
        }


    }
}
