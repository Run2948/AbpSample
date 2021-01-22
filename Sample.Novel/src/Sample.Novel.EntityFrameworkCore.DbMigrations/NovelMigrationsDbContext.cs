using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Category.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.DbMigrations
{
    [ConnectionStringName("Novel")]
    public class NovelMigrationsDbContext : AbpDbContext<NovelMigrationsDbContext>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ChapterText> ChapterTexts { get; set; }

        public NovelMigrationsDbContext(DbContextOptions<NovelMigrationsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Sample.Novel.EntityFrameworkCore"));

        } 
    }
}
