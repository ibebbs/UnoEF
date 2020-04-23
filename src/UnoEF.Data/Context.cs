using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UnoEF.Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseNpgsql(@"User ID=ahzvnzhr;Password=mYRyqmL2X0QiCmzzMU14wSlgL9493Sjv;Server=dumbo.db.elephantsql.com;Port=5432;Database=ahzvnzhr;Pooling=true;", o => o.SetPostgresVersion(new System.Version(9, 6)))
                .UseLoggerFactory(Logging.Factory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    BlogId = 1,
                    Url = "https://ian.bebbs.co.uk"
                }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    BlogId = 1,
                    PostId = 1,
                    Content = "Yes, it's possible",
                    Title = "Using EntityFrameworkCore from Uno"
                }
            );
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
