using Domain.Entities.ExcelReader;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping.ExcelReader
{
    public class ExcelReaderClienteMap : IEntityTypeConfiguration<ExcelReaderCliente>
    {
        public void Configure(EntityTypeBuilder<ExcelReaderCliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).HasColumnName("nome");
            builder.Property(e => e.Documento).HasColumnName("documento");
            builder.Property(e => e.Telefone).HasColumnName("telefone");
            builder.Property(e => e.TipoPessoa).HasColumnName("tipoPessoa");
            builder.Property(e => e.CodCliente).HasColumnName("codCliente");
            builder.Property(e => e.DataCriacao)
                    .HasColumnName("dataCriacao")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
        }
    }
}
