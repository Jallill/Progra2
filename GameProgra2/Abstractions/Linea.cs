using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Punto
    {
        public float x { get; private set; }
        public float y { get; private set; }

        public Punto(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Linea
    {
        float xInicio;
        float yInicio;
        float xFinal;
        float yFinal;
        float distancia;
        float direccion;

        List<Punto> list = new List<Punto>();

        public Linea(float xInicio, float yInicio, float xFinal, float yFinal)
        {
            this.xInicio = xInicio;
            this.yInicio = yInicio;
            this.xFinal = xFinal;
            this.yFinal = yFinal;

            float dx = xFinal - xInicio;
            float dy = yFinal - yInicio;
            int steps, k, xf, yf;
            float xIncrement, yIncrement; 
            float x = xInicio;
            float y = yInicio;

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = (int)Math.Abs(dx);
            else
                steps = (int)Math.Abs(dy);

            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;

            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                xf = (int)x;
                y += yIncrement;
                yf = (int)y;

                list.Add(new Punto(xf+32, yf+32));
            }

        }

        public void DibujarLinea()
        {
            list.ForEach(punto => Engine.Draw("Textures/Pixel.png", punto.x, punto.y));
        }

    }
}
