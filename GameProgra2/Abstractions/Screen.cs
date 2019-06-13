using Game.Interfaces;
using System;
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
            AgregarDatos();
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

        private void AgregarDatos()
        {
            int num = 0;
            do
            {
                Console.WriteLine("Ingrese un numero para agregar al arbol");
                Console.WriteLine("Ingrese -1 para terminar de agregar");
                string aux = Console.ReadLine();
                aux.Trim();
                if (aux != null && aux != "")
                {
                    int valor;
                    if (int.TryParse(aux, out valor))
                    {
                        num = valor;
                        if (num >= 0) arbol.AgregarElem(num);
                    }
                }
                Console.Clear();
            } while (num >= 0);
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
