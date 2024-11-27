using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models.Usuario;

namespace Agrotienda_2.models
{
    public class Carrito
    {
        public int CarritoId {get;set;}
        public DateTime Fecha_Creacion {get;set;}

        public int UsuarioId {get;set;}
        public Usuario Usuario {get;set;}
        
    }
}