using Microsoft.EntityFrameworkCore;
using PRUEBALOGIN.Models;
namespace PRUEBALOGIN.Data
{
   public class UsersContext : DbContext
   {
        
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
        
    }
        public DbSet<LoginModel> Users {get; set;}
    }
}
