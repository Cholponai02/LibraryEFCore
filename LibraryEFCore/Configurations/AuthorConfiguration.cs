using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryEFCore.Entities;


namespace LibraryEFCore.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(i => i.FullName)
                .HasColumnType("nvarchar(200)")
                .IsRequired(); 

            builder.Property(i => i.Country)
               .HasColumnName("country")
               .HasColumnType("nvarchar(100)")
               .IsRequired();
        }
    }   
}
