using System;
using System.Collections.Generic;
using System.Text;

namespace Abstracciones
{
    /// <summary>
    /// Clase base que contiene las propiedades que todos los objetos que 
    /// van a mostrarse graficamente comparten.
    /// </summary>
    public abstract class EntidadBase
    {
        public float X { get; set; }
        public float Y { get; set; }
        protected string Sprite { get; set; }
        
    }
}
