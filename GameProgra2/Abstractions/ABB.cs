using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game
{
    public class ABB : IABBTDA
    {
        private List<int> listaValores;

        private Dictionary<int, float[]> position = new Dictionary<int, float[]>();
        
        public ABB()
        {
            listaValores = new List<int>();
            GenerarValoresAleatorios();
            position.Add(0, new float[] { 512f });
            position.Add(1, new float[] { 256f, 768f });
            position.Add(2, new float[] { 128f, 384f, 640f, 896f });
            position.Add(3, new float[] { 64f, 192f, 320f, 448f, 576f, 704f, 832f, 960f });
            position.Add(4, new float[] { 32f, 96f, 160f, 224f, 288f, 352f, 416f, 480f, 544f, 608f, 672f, 736f, 800f, 864f, 928f, 992f });
        }

        NodoABB raiz;

        public NodoABB ObtenerRaiz()
        {
            return raiz;
        }

        public void AgregarElem(int x)
        {
            AgregarElemento(x, 0, 512, 0, 1, 1, 1);
        }
        
        public void AgregarElemento(int x, int level, float xPos, float yPos, float xscale, float yscale, int pos)
        {
            if (raiz == null)
            {
                if (position.ContainsKey(level))
                {
                    raiz = new NodoABB();
                    raiz.info = x;
                    raiz.level = level;
                    raiz.x = position[level][pos - 1];
                    raiz.y = yPos;
                    raiz.xscale = xscale;
                    raiz.yscale = yscale;
                    raiz.hijoIzq = new ABB();
                    raiz.hijoIzq.InicializarArbol();
                    raiz.hijoDer = new ABB();
                    raiz.hijoDer.InicializarArbol();
                }
            }
            else if (raiz.info > x)
            {
                level++;
                pos *= 2;
                pos--;
                raiz.hijoIzq.AgregarElemento(x, level, xPos - 100f - 50f * level, yPos + 64f, 1f, 1f, pos);
            }
            else if (raiz.info < x)
            {
                level++;
                pos *= 2;
                raiz.hijoDer.AgregarElemento(x, level, xPos + 100f + 50f * level, yPos + 64f, 1f, 1f, pos);
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

        public void PreOrder(IABBTDA a)
        {
            if (!a.ArbolVacio())
            {
                PreOrder(a.HijoIzq());
                PreOrder(a.HijoDer());
            }
        }

        /// <summary>
        /// Cargo una lista de valores aleatorios no repetibles para mostrar en el arbol.
        /// </summary>
        private void GenerarValoresAleatorios()
        {
            Random nro = new Random();

            for (int i = 0; i < 32; i++)
            {
                int num = nro.Next(1, 99);
                if (!listaValores.Contains(num))
                {
                    listaValores.Add(num);
                }
            }
            listaValores.Sort();
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
