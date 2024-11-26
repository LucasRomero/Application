using BookStoreInfrastructure;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DatabaseInitilaizer
    {
        public static void Seed(IServiceProvider  serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if(!context.EstadosOrden.Any())
            {
                context.EstadosOrden.AddRange(
                    new EstadoOrden { Id = 0, Descripcion = "En proceso" },
                    new EstadoOrden { Id = 1, Descripcion = "Completada" },
                     new EstadoOrden { Id = 2, Descripcion = "Cancelada" }
                    );
            }

            if (!context.TiposActivo.Any())
            {
                context.TiposActivo.AddRange(
                    new TipoActivo { Id = 1, Descripcion = "Acción" },
                    new TipoActivo { Id = 2, Descripcion = "Bono" },
                    new TipoActivo { Id = 3, Descripcion = "FCI" }
                );
            }


            if(!context.Activos.Any())
            {
                context.Activos.AddRange(

                    new Activo { 
                        Id = 1, 
                        Ticker = "AAPL",
                        Nombre = "Apple",
                        TipoId = 1,
                        Precio = 177.97m
                    },

                    new Activo
                    {
                        Id = 2,
                        Ticker = "GOOGL",
                        Nombre = "Alphabet Inc",
                        TipoId = 1,
                        Precio = 138.21m
                    },

                    new Activo
                    {
                        Id = 3,
                        Ticker = "MSFT",
                        Nombre = "Microsoft",
                        TipoId = 1,
                        Precio = 329.04m
                    },

                    new Activo
                    {
                        Id = 4,
                        Ticker = "KO",
                        Nombre = "Coca Cola",
                        TipoId = 1,
                        Precio = 58.3m
                    },

                    new Activo
                    {
                        Id = 5,
                        Ticker = "WMT",
                        Nombre = "Walmart",
                        TipoId = 1,
                        Precio = 163.42m
                    },

                    new Activo
                    {
                        Id = 6,
                        Ticker = "AL30",
                        Nombre = "BONOS ARGENTINA USD 2030 L.A",
                        TipoId = 2,
                        Precio = 307.4m
                    },

                    new Activo
                    {
                        Id = 7,
                        Ticker = "GD30",
                        Nombre = "Bonos Globales Argentina USD Step Up 2030",
                        TipoId = 2,
                        Precio = 336.1m
                    },

                    new Activo
                    {
                        Id = 8,
                        Ticker = "Delta.Pesos",
                        Nombre = "Delta Pesos Clase A",
                        TipoId = 3,
                        Precio = 0.0181m
                    },

                    new Activo
                    {
                        Id = 9,
                        Ticker = "Fima.Premium",
                        Nombre = "Fima Premium Clase A",
                        TipoId = 3,
                        Precio = 0.0317m
                    });
            }

            context.SaveChanges();

        }

    }
}
