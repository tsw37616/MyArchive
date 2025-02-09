using Microsoft.EntityFrameworkCore;
using System.Data;
namespace MyArchive.ApiService.Entitie
{
    public class PostContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public string DbPath { get;  set; }

        public PostContext()
        {
            DbPath = "E:/dev/repo/net9/MyArchive/db/post.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={DbPath}");

    }
}
