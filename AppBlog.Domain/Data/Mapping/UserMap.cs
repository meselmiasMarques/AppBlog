using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AppBlog.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppBlog.Domain.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.PasswordHash)
                .HasColumnName("Password")
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR");

            builder.Property(x => x.Role)
                .HasColumnType("NVARCHAR")
                .HasColumnName("Role")
                .HasMaxLength(50);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("DATETIME");


        }
    }
}
