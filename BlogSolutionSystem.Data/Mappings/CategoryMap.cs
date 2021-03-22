using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSolutionSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSolutionSystem.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);
            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "C#",
                    Description = "C# Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsDeleted = true,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C# Blog Kategorisi"
                },
                new Category
                {
                    Id = 2,
                    Name = "C++",
                    Description = "C++ Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsDeleted = true,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ Blog Kategorisi"
                },

                new Category
                {
                    Id = 3,
                    Name = "JavaScript",
                    Description = "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsDeleted = true,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript Blog Kategorisi"
                },

                new Category
                {
                    Id = 4,
                    Name = "TypeScript",
                    Description = "TypeScript Programlama Dili ile İlgili En Güncel Bilgiler",
                    IsDeleted = true,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "TypeScript Blog Kategorisi"
                },

                  new Category
                  {
                      Id = 5,
                      Name = "Php",
                      Description = "Php Programlama Dili ile İlgili En Güncel Bilgiler",
                      IsDeleted = true,
                      CreatedByName = "InitialCreate",
                      CreatedDate = DateTime.Now,
                      ModifiedByName = "InitialCreate",
                      ModifiedDate = DateTime.Now,
                      Note = "Php Blog Kategorisi"
                  },

                  new Category
                  {
                      Id = 6,
                      Name = "React Native",
                      Description = "React Native Programlama Dili ile İlgili En Güncel Bilgiler",
                      IsDeleted = true,
                      CreatedByName = "InitialCreate",
                      CreatedDate = DateTime.Now,
                      ModifiedByName = "InitialCreate",
                      ModifiedDate = DateTime.Now,
                      Note = "React Native Blog Kategorisi"
                  }
            );
        }
    }
}
