using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models;

namespace Agrotienda_2.models
{
    public class Usuario
    {
        public int UsuarioId {get; set;}
        public required String Nombre {get;set;}
        public required String Correo {get;set;}
        public required String Contraseña {get;set;} 
        public required String Direccion {get;set;}
        public required int Telefono {get;set;}
        public required String Rol {get;set;}
        public required String Historial_Compras {get;set;}
        public required String Calificaciones {get;set;}


        //Relacion con la entidad Producto//
        public ICollection<Producto> Producto {get;set;}

        //Relacion con la entidad Venta//
        public ICollection<Venta> Venta {get;set;}

        //Relacion con la entidad Chat//
        public ICollection<Chat> Chat {get;set;}

        //Relacion con la entidad Carrito//
        public ICollection<Carrito> Carrito {get;set;}

        //Relacion con la entidad Calificacion//
        public ICollection<Calificacion> Calificacion {get;set;}
    }

    
}