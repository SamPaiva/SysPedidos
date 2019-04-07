using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysPedidos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysPedidos.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.PedidoId);
            builder.Property(c => c.Cardapio).IsRequired();
            builder.Property(c => c.DataPedido).HasColumnType("Date").IsRequired();
        }
    }
}
