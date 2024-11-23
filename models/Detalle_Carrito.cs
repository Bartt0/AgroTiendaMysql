using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrotienda_2.models
{
    public class Detalle_Carrito
    {
        public int Detalle_CarritoId {get;set;}
        public int Cantidad {get;set;}
        public int Subtotal {get;set;}
    }
}