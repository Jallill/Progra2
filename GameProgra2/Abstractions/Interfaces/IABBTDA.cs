using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IABBTDA
    {
        int Raiz();
        IABBTDA HijoIzq();
        IABBTDA HijoDer();
        bool ArbolVacio();
        void InicializarArbol();
        void AgregarElem(int x);
        void EliminarElem(int x);
    }
}
