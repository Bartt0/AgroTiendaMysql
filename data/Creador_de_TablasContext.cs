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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            //Relacion foreingkey de Venta y Usuario
            modelBuilder.Entity<Venta>()
            .HasOne<Usuario>(s => s.Usuario)
            .WithMany(g => g.Venta)
            .HasForeignKey(s => s.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

            //Relacion foreingkey de Producto y Usuario// 
            modelBuilder.Entity<Producto>()
            .HasOne<Usuario>(s => s.Usuario)
            .WithMany(g => g.Producto)
            .HasForeignKey(s => s.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
        
          //Relacion foreingkey de Pasarela_Pago y Venta//
          modelBuilder.Entity<Pasarela_Pago>()
            .HasOne<Venta>(s => s.Venta)
            .WithMany(g => g.Pasarela_Pago)
            .HasForeignKey(s => s.VentaId)
            .OnDelete(DeleteBehavior.Cascade);

            //Relacion foreingkey de Detalle_Venta y Venta//
            modelBuilder.Entity<Detalle_Venta>()
            .HasOne<Venta>(s => s.Venta)
            .WithMany(g => g.Detalle_Venta)
            .HasForeignKey(s => s.VentaId)
            .OnDelete(DeleteBehavior.Cascade);
           //Relacion foreingkey de Detalle_Venta y Producto//
            modelBuilder.Entity<Detalle_Venta>()
            .HasOne<Producto>(s => s.Producto)
            .WithMany(g => g.Detalle_Venta)
            .HasForeignKey(s => s.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);
             //Relacion foreingkey de Detalle_Carrito y Carrito//
            modelBuilder.Entity<Detalle_Carrito>()
            .HasOne<Carrito>(s => s.Carrito)
            .WithMany(g => g.Detalle_Carrito)
            .HasForeignKey(s => s.CarritoId)
            .OnDelete(DeleteBehavior.Cascade);
            //Relacion foreingkey de Detalle_Carrito y producto//
            modelBuilder.Entity<Detalle_Carrito>()
            .HasOne<Producto>(s => s.Producto)
            .WithMany(g => g.Detalle_Carrito)
            .HasForeignKey(s => s.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);
            //Relacion foreingkey de Chat y Usuario//
             modelBuilder.Entity<Chat>()
            .HasOne<Usuario>(s => s.Usuario)
            .WithMany(g => g.Chat)
            .HasForeignKey(s => s.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
           //Relacion foreingkey de Carrito y Usuario//
             modelBuilder.Entity<Carrito>()
            .HasOne<Usuario>(s => s.Usuario)
            .WithMany(g => g.Carrito)
            .HasForeignKey(s => s.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
            //Relacion foreingkey de Calificacion y Usuario//
             modelBuilder.Entity<Calificacion>()
            .HasOne<Usuario>(s => s.Usuario)
            .WithMany(g => g.Calificacion)
            .HasForeignKey(s => s.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
            //Relacion foreingkey de Calificacion y Producto//
            modelBuilder.Entity<Calificacion>()
            .HasOne<Producto>(s => s.Producto)
            .WithMany(g => g.Calificacion)
            .HasForeignKey(s => s.ProductoId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}