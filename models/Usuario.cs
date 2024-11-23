using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}