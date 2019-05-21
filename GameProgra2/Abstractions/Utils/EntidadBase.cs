using System;
using System.Collections.Generic;
using System.Text;
using Game;

namespace Abstractions
{
    /// <summary>
    /// Clase base que contiene las propiedades que todos los objetos que 
    /// van a mostrarse graficamente comparten.
    /// </summary>
    public abstract class BaseEntity
    {
        public Vector2D vector2 { get; private set; }
        protected Animation Sprite { get; private set; }
        
    }
}
