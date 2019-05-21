using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Node
    {
        public Node greaterNode { get; private set; }
        public Node lesserNode { get; private set; }
        public Node fatherNode { get; set; }

        //Esta propiedad define si este nodo es el que tiene seleccionado actualmente el usuario.
        public bool selected { get; set; }
        public int value { get; private set; }


        public Node(int value, Node lesserNode = null, Node greaterNode = null)
        {
            this.value = value;
            this.lesserNode = lesserNode;
            this.greaterNode = greaterNode;
        }

        public Node AddNode(int value, Node node)
        {
            if (node == null)
            {
                node = new Node(value);
            }
            else if (value < node.value)
            {
                node.lesserNode = AddNode(value, node.lesserNode);
            }
            else if (value > node.value)
            {
                node.greaterNode = AddNode(value, node.greaterNode);
            }
            else
            {
                Engine.Debug("Dato ya existente");
            }

            return node;
        }

        public Node SearchNode(int value, Node node)
        {
            if (node != null)
            {
                if (value == node.value)
                {
                    Engine.Debug("Se encontro el valor");
                }
                else if (value < node.value)
                {
                    node.SearchNode(value, node.lesserNode);
                }
                else if (value > node.value)
                {
                    node.SearchNode(value, node.greaterNode);
                }
            }
            else
            {
                Engine.Debug("No se encontro el valor");
                return null;
            }

            return node;
        }
    }
}
