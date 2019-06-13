using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game
{
    class ABB : IABBTDA
    {
        private List<int> listaValores;
        public ABB()
        {
            listaValores = new List<int>();
            GenerarValoresAleatorios();
        }

        NodoABB raiz;
        
        public void AgregarElem(int x, int level = 0)
        {
            if (raiz == null)
            {
                raiz = new NodoABB();
                raiz.info = x;
                raiz.level = level;
                raiz.hijoIzq = new ABB();
                raiz.hijoIzq.InicializarArbol();
                raiz.hijoDer = new ABB();
                raiz.hijoDer.InicializarArbol();
            }
            else if (raiz.info > x)
            {
                level++;
                raiz.hijoIzq.AgregarElem(x, level);
            }
            else if (raiz.info < x)
            {
                level++;
                raiz.hijoDer.AgregarElem(x, level);
            }
        }

        public bool ArbolVacio()
        {
            return raiz == null;
        }

        public void EliminarElem(int x)
        {
            if (raiz != null)
            {
                if (raiz.info == x && raiz.hijoIzq.ArbolVacio() &&
             raiz.hijoDer.ArbolVacio())
                {
                    raiz = null;
                }
                else if (raiz.info == x && !raiz.hijoIzq.ArbolVacio())
                {
                    raiz.info = mayor(raiz.hijoIzq);
                    raiz.hijoIzq.EliminarElem(raiz.info);
                }
                else if (raiz.info == x && raiz.hijoIzq.ArbolVacio())
                {
                    raiz.info = menor(raiz.hijoDer);
                    raiz.hijoDer.EliminarElem(raiz.info);
                }
                else if (raiz.info < x)
                {
                    raiz.hijoDer.EliminarElem(x);
                }
                else
                {
                    raiz.hijoIzq.EliminarElem(x);
                }
            }
        }

        private int mayor(IABBTDA a)
        {
            if (a.HijoDer().ArbolVacio())
            {
                return a.Raiz();
            }
            else
            {
                return mayor(a.HijoDer());
            }
        }

        private int menor(IABBTDA a)
        {
            if (a.HijoIzq().ArbolVacio())
            {
                return a.Raiz();
            }
            else
            {
                return menor(a.HijoIzq());

            }
        }

        public IABBTDA HijoDer()
        {
            return raiz.hijoDer;
        }

        public IABBTDA HijoIzq()
        {
            return raiz.hijoIzq;
        }

        public void InicializarArbol()
        {
            raiz = null;
        }

        public int Raiz()
        {
            return raiz.info;
        }

        /// <summary>
        /// Cargo una lista de valores aleatorios no repetibles para mostrar en el arbol.
        /// </summary>
        private void GenerarValoresAleatorios()
        {
            Random nro = new Random();
            bool terminado = false;

            while (!terminado)
            {
                int aux = nro.Next(1, 99);
                if (listaValores.Contains(aux))
                {
                    listaValores.Add(aux);
                }
                if (listaValores.Count == 32)
                    terminado = true;
            }
            OrdenarLista();
        }

        /// <summary>
        /// Ordeno una lista de valores de menor a mayor.
        /// </summary>
        private void OrdenarLista()
        {
            for (int i = 0; i < listaValores.Count; i++)
            {
                for (int j = 0; j < listaValores.Count; j++)
                {
                    if (listaValores[j] < listaValores[i])
                    {
                        int aux = listaValores[i];
                        listaValores.Insert(i, listaValores[j]);
                        listaValores.Insert(j, aux);
                    }
                }
            }
        }
    }
}
