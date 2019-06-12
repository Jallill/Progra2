using Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstracciones
{
    public interface INodeManager
    {
        /// <summary>
        /// Metodo para buscar nodos por valor.
        /// Al momento de mostrar los nodos, puede ser que mas de uno compartan el mismo valor.
        /// De ser necesario, generar submetodos correspondientes para mostrar varias opcion al
        /// usuario, y darle a elegir la que el esta buscando.
        /// </summary>
        /// <param name="value">Valor a buscar.</param>
        void SearchNode(int value);

        /// <summary>
        /// Metodo para agregar un nuevo Nodo.
        /// </summary>
        /// <param name="id">
        /// Nodo del que va a depender. En caso de depender directamente de la rama principal,
        /// el valor debe ser 0.
        /// </summary>
        /// <param name="value">Valor que se va a cargar en el nodo.</param>
        /// <param name="nodoPadre">Nodo padre al que se va a adherir.</param>
        void AddNode(int value, NodoABB nodoPadre);

        /// <summary>
        /// Elimina un nodo.
        /// </summary>
        /// <param name="value">Valor del nodo que se quiere eliminar.</param>
        void DeleteNode(int value);

        /// <summary>
        /// Cambio la posicion de seleccion del nodo actual al superior de este.
        /// </summary>
        /// <param name="nodoActual">Nodo actualmente seleccionado.</param>
        void SelectGreaterNode(NodoABB nodoActual);

        /// <summary>
        /// Cambio la posicion de seleccion del nodo actual al inferior de este.
        /// </summary>
        /// <param name="nodoActual">Nodo actualmente seleccionado.</param>
        void SelectLesserNode(NodoABB nodoActual);

        /// <summary>
        /// Cambio la posicion de seleccion del nodo actual al padre de este.
        /// </summary>
        /// <param name="nodoActual">Nodo actualmente seleccionado.</param>
        //void SelectFatherNode(NodoABB nodoActual);
    }
}
