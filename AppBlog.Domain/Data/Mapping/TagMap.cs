using AppBlog.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppBlog.Domain.Data.Mapping
{
    internal class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);


            builder
                .HasMany(x => x.Posts)
                .WithMany(x => x.Tags)
                .UsingEntity<Dictionary<string, object>>(
                    "TagPost",
                    post => post
                        .HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_TagPost_PostID")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag
                        .HasOne<Tag>()
                        .WithMany()
                    .HasForeignKey("TagId")
                        .HasConstraintName("FK_TagPost_PostId")
                        .OnDelete(DeleteBehavior.Cascade));


        }
    }
}
