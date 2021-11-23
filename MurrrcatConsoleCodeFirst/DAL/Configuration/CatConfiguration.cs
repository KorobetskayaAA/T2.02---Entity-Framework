using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MurrrcatConsoleCodeFirst.DAL.Configuration
{
    class CatConfiguration : IEntityTypeConfiguration<Cat>
    {
        public void Configure(EntityTypeBuilder<Cat> builder)
        {
            // необязательно - сработает convention
            builder.HasKey("Id");

            builder.Property(cat => cat.Id)
                .HasMaxLength(50);

            builder.Property(cat => cat.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(cat => cat.Description)
                .HasColumnType("ntext");

            // необязательно - сработает convention
            builder
                .HasOne(cat => cat.Owner)
                .WithMany(owner => owner.Cats)
                .HasForeignKey("OwnerId");

            // необязательно - сработает convention
            builder
                .HasMany(cat => cat.Categories)
                .WithMany(category => category.Cats);
        }
    }
}
