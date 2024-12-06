using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models;

namespace Agrotienda_2.models
{
    public class Detalle_Venta
    {
        public int Detalle_VentaId {get;set;}
        public String Cantidad {get;set;}
        public Decimal Precio_Unitario {get;set;}
        public Decimal Subtotal {get;set;}

        public int VentaId {get;set;}
        public Venta Venta {get;set;}
        

        public int ProductoId {get;set;}
        public Producto Producto {get;set;}
        
    }
}