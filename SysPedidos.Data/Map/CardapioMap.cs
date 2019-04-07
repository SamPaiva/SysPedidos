using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysPedidos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysPedidos.Data.Map
{
    public class CardapioMap : IEntityTypeConfiguration<Cardapio>
    {
        public void Configure(EntityTypeBuilder<Cardapio> builder)
        {
            builder.HasKey(c => c.CardapioId);
            builder.Property(c => c.CardapioId).ValueGeneratedOnAdd();
            builder.Property(c => c.DescItem).IsRequired().HasMaxLength(200);
            builder.Property(c => c.ItensCardapio).IsRequired();
        }
    }
}
