using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Node
    {

        public Node greaterNode { get; set; }
        public Node lesserNode { get; set; }

        public int value { get; private set; }

        public Node(int value, Node lesserNode = null, Node greaterNode = null)
        {
            this.value = value;
            this.lesserNode = lesserNode;
            this.greaterNode = greaterNode;
        }

        public Node addNode(int value, Node node)
        {
            if (node == null)
            {
                node = new Node(value);
            }
            else if (value < node.value)
            {
                node.lesserNode = addNode(value, node.lesserNode);
            }
            else if (value > node.value)
            {
                node.greaterNode = addNode(value, node.greaterNode);
            }
            else
            {
                Engine.Debug("Dato ya existente");
            }

            return node;
        }

        public Node searchNode(int value, Node node)
        {
            if(node != null)
            {
                if (value == node.value)
                {
                    Engine.Debug("Se encontro el valor");
                }
                else if (value < node.value)
                {
                    node.searchNode(value, node.lesserNode);
                }
                else if (value > node.value)
                {
                    node.searchNode(value, node.greaterNode);
                }
                else
                {
                    Engine.Debug("No se encontro el valor");
                }
            }

            return node;
        }
    }
