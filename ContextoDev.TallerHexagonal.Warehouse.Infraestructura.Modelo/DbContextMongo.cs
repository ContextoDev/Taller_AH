using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContextoDev.TallerHexagonal.Warehouse.Infraestructura.Modelo
{
    public class DbContextMongo:DbContext
    {
        public DbContextMongo(DbContextOptions<DbContextMongo> options):base(options)
        {
            
        }

        public DbContextMongo(DbContextOptions options) : base(options)
        {
        }
    }
}
