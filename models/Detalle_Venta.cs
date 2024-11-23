using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrotienda_2.models
{
    public class Detalle_Venta
    {
        public int Detalle_VentaId {get;set;}
        public String Cantidad {get;set;}
        public Decimal Precio_Unitario {get;set;}
        public Decimal Subtotal {get;set;}
    }
}