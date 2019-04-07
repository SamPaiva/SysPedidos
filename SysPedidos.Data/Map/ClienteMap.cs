using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysPedidos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysPedidos.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ClienteId);
            builder.Property(c => c.ClienteId).ValueGeneratedOnAdd();
            builder.Property(c => c.DataCriacao).IsRequired().HasColumnType("Date");
            builder.Property(c => c.Endereco).HasMaxLength(200).IsRequired();
            builder.Property(c => c.NomeCliente).HasMaxLength(70).IsRequired();
            builder.Property(c => c.Telefone).HasMaxLength(10).IsRequired();
        }
    }
}
