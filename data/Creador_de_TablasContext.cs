using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrotienda_2.models;
using Microsoft.EntityFrameworkCore;

namespace Agrotienda_2.data
{
    public class Creador_de_TablasContext: DbContext
    {
        public Creador_de_TablasContext(DbContextOptions<Creador_de_TablasContext> options) 
        : base(options)
        {
            
        }

        public DbSet<Usuario> Usuario {get;set;}
        public DbSet<Venta> Venta {get;set;}
        public DbSet<Producto> Productos {get;set;}
        public DbSet<Pasarela_Pago> Pasarela_de_Pagos {get;set;}
        public DbSet<Detalle_Venta> Detalle_de_Ventas {get;set;}
        public DbSet<Detalle_Carrito> Detalle_de_Carrito {get;set;}
        public DbSet<Chat> Chat {get;set;}
        public DbSet<Carrito> Carrito {get;set;}
        public DbSet<Calificacion> Calificacion {get;set;}
    }
}