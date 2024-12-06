using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models;

namespace Agrotienda_2.models
{
    public class Detalle_Carrito
    {
        public int Detalle_CarritoId {get;set;}
        public int Cantidad {get;set;}
        public int Subtotal {get;set;}

        public int CarritoId {get;set;}
        public Carrito Carrito {get;set;}
        

        public int ProductoId {get;set;}
        public Producto Producto {get;set;}
        
    }
}