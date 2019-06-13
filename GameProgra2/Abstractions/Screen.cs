using Game.Interfaces;
using System.Collections.Generic;

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
            a.ObtenerRaiz().Render();
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
