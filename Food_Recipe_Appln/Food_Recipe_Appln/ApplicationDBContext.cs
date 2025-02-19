using Food_Recipe_Appln.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Food_Recipe_Appln
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        public DbSet<Login> tbl_Login { get; set; }
        public DbSet<Recipe> tbl_Recipe { get; set; }
        
    }
}
