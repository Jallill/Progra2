using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public delegate void DrawColliderDelegate();

    public class Collider : Vector2D
    {

        private DrawColliderDelegate drawCollider;

        public DrawColliderDelegate DrawCollider {
            get {
                return drawCollider;
            }

            set {
                drawCollider = value;
            }
        }

        bool isCollisionable;
        bool isCircle;

        float radius;
        
        protected float sizeX { get; private set; }
        protected float sizeY { get; private set; }

        public Collider(float x, float y, float sizeX, float sizeY, bool isCollisionable, bool isCircle) : base(x, y)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            radius = sizeX / 2;

            this.isCollisionable = isCollisionable;
            this.isCircle = isCircle;

            drawCollider = isCircle ? new DrawColliderDelegate(DrawCircleCollider) : new DrawColliderDelegate(DrawBoxCollider);

        }

        public Collider getCollider()
        {
            return this;
        }

        private static bool CheckBoxCircleCollision(Collider collisionCircle, Collider collisionBox)
        {

            float deltaX = collisionCircle.x - Math.Max(collisionBox.x, Math.Min(collisionCircle.x, collisionBox.x + collisionBox.sizeX));
            float deltaY = collisionCircle.y - Math.Max(collisionBox.y, Math.Min(collisionCircle.y, collisionBox.y + collisionBox.sizeY));

            return Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) < Math.Pow(collisionCircle.radius, 2);
        }

        private static bool CheckCircleCircleCollision(Collider collisionCircle1, Collider collisionCircle2)
        {
            var radius = collisionCircle1.sizeX / 2 + collisionCircle2.sizeX / 2;
            var deltaX = collisionCircle1.x - collisionCircle2.x;
            var deltaY = collisionCircle1.y - collisionCircle2.y;
            return Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) <= Math.Pow(radius, 2);
        }

        public static bool CheckCollision(Collider collider1, Collider collider2)
        {

            if (collider1.isCollisionable && collider2.isCollisionable)
            {

                Collider collisionCircle;
                Collider collisionBox;

                if (collider1.isCircle && collider2.isCircle)
                {
                    return CheckCircleCircleCollision(collider1, collider2);
                }
                if (collider1.isCircle)
                {
                    collisionCircle = collider1;
                    collisionBox = collider2;
                }
                else
                {
                    collisionCircle = collider2;
                    collisionBox = collider1;
                }
                return CheckBoxCircleCollision(collisionCircle, collisionBox);
            }
            return false;
        }

        protected void DrawBoxCollider()
        {
            for (float i = x; i < x + sizeX; i++)
            {
                Engine.Draw("Textures/Utils/Pixel.png", i, y);
                Engine.Draw("Textures/Utils/Pixel.png", i, y + sizeY);
            }
            for (float i = y; i < y + sizeY; i++)
            {
                Engine.Draw("Textures/Utils/Pixel.png", x, i);
                Engine.Draw("Textures/Utils/Pixel.png", x + sizeX, i);
            }
        }

        protected void DrawCircleCollider()
        {
            float drawX;
            float drawY;
            for (float i = 0; i <= 360; i++)
            {
                drawX = (float)Math.Cos((i) * Math.PI / 180) * radius;
                drawY = (float)Math.Sin((i) * Math.PI / 180) * radius;
                Engine.Draw("Textures/Utils/Pixel.png", x + drawX, y + drawY);
            }
        }

    }
}
