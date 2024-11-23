using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agrotienda_2.models
{
    public class Calificacion
    {
        public int CalificacionId {get;set;}
        public String Puntuacion {get;set;}
        public String Comentarios {get;set;}
    }
}