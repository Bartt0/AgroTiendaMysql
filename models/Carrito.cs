using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models;

namespace Agrotienda_2.models
{
    public class Carrito
    {
        public int CarritoId {get;set;}
        public DateTime Fecha_Creacion {get;set;}
         
         //Clave foranea hacia Usuario//
        public int UsuarioId {get;set;}
        public Usuario Usuario {get;set;}

        //Relacion con la entidad Detalle_Carrito//
        public ICollection<Detalle_Carrito> Detalle_Carrito {get;set;}
        
    }
}