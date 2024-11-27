using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models.Venta;

namespace Agrotienda_2.models
{
    public class Pasarela_Pago
    {
        public int Pasarela_PagoId {get;set;}
        public required String Tipo_Pago {get;set;}
        public required String Estado_Transaccion {get;set;}

        public int VentaId {get;set;}
        public Venta Venta {get;set;}
        
    }
}