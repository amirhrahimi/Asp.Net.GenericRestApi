using Microsoft.EntityFrameworkCore;
using Rahimi.AspNet.GenericRestApi.Core.Domain;

namespace Rahimi.AspNet.GenericRestApi.Infrastructure.DataAccess
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
      : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
