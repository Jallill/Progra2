using System;
using System.Collections.Generic;
using System.Text;

namespace Abstracciones
{
    public interface IGestorNodos
    {
        /// <summary>
        /// Metodo para buscar nodos por valor.
        /// Al momento de mostrar los nodos, puede ser que mas de uno compartan el mismo valor.
        /// De ser necesario, generar submetodos correspondientes para mostrar varias opcion al
        /// usuario, y darle a elegir la que el esta buscando.
        /// </summary>
        /// <param name="valor">Valor a buscar.</param>
        void BuscarNodoPorValor(int valor);

        /// <summary>
        /// Metodo para buscar nodos por Id. Al ser unico el ID, siempre va a encontrar unicamente
        /// un solo nodo del arbol.
        /// </summary>
        /// <param name="id">Id para buscar el nodo.</param>
        void BuscarNodoPorId(int id);

        /// <summary>
        /// Metodo para agregar un nuevo Nodo.
        /// </summary>
        /// <param name="id">
        /// Nodo del que va a depender. En caso de depender directamente de la rama principal,
        /// el valor debe ser 0.
        /// </param>
        /// <param name="valor">Valor a cargar en el Nodo.</param>
        void AgregarNodo(int id, int valor);

        /// <summary>
        /// Elimina un nodo.
        /// </summary>
        /// <param name="id">ID del nodo que se quiere eliminar.</param>
        void EliminarNodo(int id);
    }
}
