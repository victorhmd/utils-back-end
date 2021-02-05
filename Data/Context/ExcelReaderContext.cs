using Data.Mapping.ExcelReader;
using Domain.Entities.ExcelReader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class ExcelReaderContext : DbContext
    {
        public ExcelReaderContext(DbContextOptions<ExcelReaderContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExcelReaderClienteMap());
        }

        public DbSet<ExcelReaderCliente> Cliente { get; set; }
    }
}
