using Microsoft.EntityFrameworkCore;
using tp.Models;

namespace tp.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Student> Students { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}