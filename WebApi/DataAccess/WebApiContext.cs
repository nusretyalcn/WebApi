using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class WebApiContext:DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
