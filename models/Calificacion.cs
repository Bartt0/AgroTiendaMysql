using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models;

namespace Agrotienda_2.models
{
    public class Calificacion
    {
        public int CalificacionId {get;set;}
        public required String Puntuacion {get;set;}
        public String Comentarios {get;set;}

        //Clave Foranea hacia Producto//
        public int ProductoId {get;set;}
        public Producto Producto {get;set;}
        
       //Clave Foranea hacia Usuario//
        public int UsuarioId {get;set;}
        public Usuario Usuario {get;set;}
    }
}