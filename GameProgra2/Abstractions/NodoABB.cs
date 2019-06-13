using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class NodoABB
    {
        public int info;
        public ABB hijoIzq;
        public ABB hijoDer;
        public int level;
        public float x;
        public float y;
        public float xscale;
        public float yscale;
        public Linea izq;
        public Linea der;
        
       
        public void Render()
        {

            if(hijoDer.ObtenerRaiz() != null)
            {
                new Linea(x, y, hijoDer.ObtenerRaiz().x, hijoDer.ObtenerRaiz().y).DibujarLinea();
            }
            if(hijoIzq.ObtenerRaiz() != null)
            {
                new Linea(x, y, hijoIzq.ObtenerRaiz().x, hijoIzq.ObtenerRaiz().y).DibujarLinea();
            }
            Engine.Draw("Textures/NodeCircle/001.png", x, y, xscale, yscale);
            string a;
            if (info < 10) a = "0" + info.ToString(); else a = info.ToString(); 
            
            new Text(a, x + 28, y + 48, 24, 24).drawText();
        }
    }
}