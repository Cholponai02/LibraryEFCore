using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryEFCore.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnType("int")
                .IsRequired(); 

            builder.Property(i => i.TitleBook)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
            builder.Property(i => i.Genre)
               .HasColumnType("nvarchar(100)")
               .IsRequired();
        }
    }
}

