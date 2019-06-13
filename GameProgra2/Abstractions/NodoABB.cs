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
       
        public void Render()
        {
            Engine.Draw("Textures/NodeCircle/001.png", x, y, xscale, yscale);
        }
    }
}