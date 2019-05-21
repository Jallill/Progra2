using Abstracciones;
using System;

namespace Game
{
    public class NodeSelector : INodeManager
    {
        public void AddNode(int value, Node nodoPadre)
        {
            throw new NotImplementedException();
        }

        public void DeleteNode(int value)
        {
            throw new NotImplementedException();
        }

        public void SearchNode(int value)
        {
            throw new NotImplementedException();
        }

        public void SelectFatherNode(Node nodoActual)
        {
            nodoActual.selected = false;
            nodoActual.fatherNode.selected = true;
        }

        public void SelectGreaterNode(Node nodoActual)
        {
            nodoActual.selected = false;
            nodoActual.greaterNode.selected = true;
        }

        public void SelectLesserNode(Node nodoActual)
        {
            nodoActual.selected = false;
            nodoActual.lesserNode.selected = true;
        }
    }
}
