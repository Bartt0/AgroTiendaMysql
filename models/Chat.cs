using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models.Usuario;

namespace Agrotienda_2.models
{
    public class Chat
    {
        public int ChatId {get;set;}
        public String Mensaje {get;set;}
        public DateTime Fecha_Mensaje {get;set;}

        public int UsuarioId {get;set;}
        public Usuario Usuario {get;set;}
        
    }
}