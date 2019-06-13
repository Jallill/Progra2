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
        public IABBTDA hijoIzq;
        public IABBTDA hijoDer;
        public int level;
    }
}