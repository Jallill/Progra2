using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Screen : IBaseMethods
    {

        private ABB arbol = new ABB();
        private List<IABBTDA> listaNodos = new List<IABBTDA>();

        public Screen()
        {
            SetUp();
        }

        private void SetUp()
        {
            arbol.InicializarArbol();
            arbol.AgregarElem(10);
            arbol.AgregarElem(7);
            arbol.AgregarElem(25);
            arbol.AgregarElem(6);
            arbol.AgregarElem(14);
            arbol.AgregarElem(15);

            Engine.Debug(CalcularProfundidad(arbol, 5));
        }

        private void PreOrder(IABBTDA a, bool hijoIzq)
        {
            if (!a.ArbolVacio())
            {
                Dibujar(a, hijoIzq);
                PreOrder(a.HijoIzq(), true);
                PreOrder(a.HijoDer(), false);
            }
        }

        private void Dibujar(IABBTDA a, bool hijoIzq)
        {
            if (hijoIzq)
            {
                DibujarNodo(a, -1);
            }
            else
            {
                DibujarNodo(a, 1);
            }
        }

        private void DibujarNodo(IABBTDA a, int factor)
        {
            Engine.Draw("Textures/NodeCircle/001.png",
                                        Program.width / 2 + factor * 64 * CalcularProfundidad(arbol, a.Raiz()),
                                        32 + CalcularProfundidad(arbol, a.Raiz()) * 64,
                                        offsetX: 32,
                                        offsetY: 32);
            Engine.Debug("Se dibujó: " + a.Raiz());
        }

        private int CalcularProfundidad(IABBTDA t, int x)
        {
            if(t.ArbolVacio())
            {
                return 0;
            }
            else if(t.Raiz() == x)
            {
                return 0;
            }
            else if (t.Raiz() > x)
            {
                return (1 + CalcularProfundidad(t.HijoIzq(), x));
            }
            else
            {
                return (1 + CalcularProfundidad(t.HijoDer(), x));
            }
        }

        public void Input()
        {

        }


        public void Update()
        {

        }


        public void Render()
        {
            PreOrder(arbol, false);
        }
    }
}
