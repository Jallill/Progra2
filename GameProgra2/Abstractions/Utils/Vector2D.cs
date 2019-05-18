using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Vector2D
    {
        public float x { get; protected set; }
        public float y { get; protected set; }

        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    
        public Vector2D Vector2()
        {
            return this;
        }

        public float lengthSquared()
        {
            return (this.x * this.x + this.y * this.y);
        }

        public float length()
        {
            return (float)Math.Sqrt(this.lengthSquared());
        }

        public Vector2D clone()
        {
            return new Vector2D(this.x, this.y);
        }

        public void negate()
        {
            this.x = -this.x;
            this.y = -this.y;
        }

        public Vector2D normalize()
        {
            float length = this.length();
            if (length > 0)
            {
                this.x /= length;
                this.y /= length;
            }
            return this; //return this.length();
        }

        public Vector2D add(Vector2D vec)
        {
            return new Vector2D(this.x + vec.x, this.y + vec.y);
        }

        public Vector2D multiply(float mfactor)
        {
            return new Vector2D(this.x * mfactor, this.y * mfactor);
        }

        public void incrementBy(Vector2D vec)
        {
            this.x += vec.x;
            this.y += vec.y;
        }

        public Vector2D subtract(Vector2D vec)
        {
            return new Vector2D(this.x - vec.x, this.y - vec.y);
        }

        public void decrementBy(Vector2D vec)
        {
            this.x -= vec.x;
            this.y -= vec.y;
        }

        public void scaleBy(float k)
        {
            this.x *= k;
            this.y *= k;
        }

        public float dotProduct(Vector2D vec)
        {
            return (this.x * vec.x + this.y * vec.y);
        }

        // STATIC METHODS
        public static float distance(Vector2D vec1, Vector2D vec2)
        {
            return (vec1.subtract(vec2)).length();
        }

        public static float angleBetween(Vector2D vec1, Vector2D vec2)
        {
            return (float)Math.Acos(vec1.dotProduct(vec2) / (vec1.length() * vec2.length()));
        }

        public static float[] midPoint(float x1, float y1, float x2, float y2)
        {
            float[] mP = new float[2];

            if (x1 < x2)
            {
                mP[0] = x1 + (x2 - x1) / 2;
            }
            else
            {
                mP[0] = x2 + (x1 - x2) / 2;
            }

            if (y1 < y2)
            {
                mP[1] = y1 + (y2 - y1) / 2;
            }
            else
            {
                mP[1] = y2 + (y1 - y2) / 2;
            }

            return mP;
        }
    }
}
