using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models.Usuario;

namespace Agrotienda_2.models
{
    public class Producto
    {
        public int ProductoId {get;set;}
        public required String Nombre {get;set;}
        public required String Descripcion {get;set;}
        public required Decimal Precio {get;set;}
        public required int Stock {get;set;}
       
       //Clave Foranea hacia Usuario //
        public int UsuarioId {get;set;}
        public Usuario Usuario {get;set;}
        
    }
}