using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrotienda_2.models
{
    public class Venta
    {
        public int VentaId {get;set;}
        public required DateTime Fecha_Venta {get;set;}
        public required Decimal Total {get;set;}
        public required String Metodo_Pago {get;set;}
        public required String Direccion_Entrega {get;set;}
    }
}