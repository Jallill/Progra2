using System;
using System.Collections.Generic;
using System.Text;

namespace Abstracciones
{
    public interface IGestorVisualizador
    {
        /// <summary>
        /// Me posiciono en el nodo menor que depende del nodo en el que
        /// estamos actualmente.
        /// </summary>
        void AccederNodoMenor();

        /// <summary>
        /// Me posiciono en el nodo mayor que depende del nodo en el que
        /// estamos actualmente.
        /// </summary>
        void AccederNodoMayor();

        /// <summary>
        /// Me posiciono en el nodo padre del que depende en el que estamos
        /// actualmente.
        /// </summary>
        void RetornoAPosicionAnterior();
    }
}
