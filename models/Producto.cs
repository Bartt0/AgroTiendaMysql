using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models;

namespace Agrotienda_2.models
{
    public class Producto
    {
        public int ProductoId {get;set;}
        public required String Nombre {get;set;}
        public  String Descripcion {get;set;}
        public required Decimal Precio {get;set;}
        public  int Stock {get;set;}
       
       //Clave Foranea hacia Usuario //
        public int UsuarioId {get;set;}
        public Usuario Usuario {get;set;}

        //Relacion con la entidad Detalle_Venta//
        public ICollection<Detalle_Venta> Detalle_Venta {get;set;}

        //Relacion con la entidad Detalle_Carrito//
        public ICollection<Detalle_Carrito> Detalle_Carrito {get;set;}

        //Relacion con la entidad Calificacion//
        public ICollection<Calificacion> Calificacion {get;set;}
        
    }
}