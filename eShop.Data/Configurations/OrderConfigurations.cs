﻿using System;
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
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.OrderDate);

            builder.Property(x => x.ShipEmail).IsRequired().IsUnicode(false).HasMaxLength(50);

            builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(200);


            builder.Property(x => x.ShipName).IsRequired().HasMaxLength(200);


            builder.Property(x => x.ShipPhoneNumber).IsRequired().HasMaxLength(200);

           

        }
    }
}
