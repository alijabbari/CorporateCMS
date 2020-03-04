using Corporate.Data.EntityConfigs;
using Corporate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Data.Context
{
    public class CorporateDb : DbContext
    {
        public CorporateDb(DbContextOptions<CorporateDb> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<TranslateEntity> Translates { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NewsCategoryMapping> NewsCategoryMappings { get; set; }
        public DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new NewsConfig());
            modelBuilder.ApplyConfiguration(new PictureConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            modelBuilder.ApplyConfiguration(new TopicConfig());
        }
    }
}
