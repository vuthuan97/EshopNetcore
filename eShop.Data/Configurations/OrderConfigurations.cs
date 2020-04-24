using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using eShop.Data.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Data.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(c => c.Id);
        }
    }
}
