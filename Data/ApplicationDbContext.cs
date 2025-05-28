using Microsoft.EntityFrameworkCore;
using NeosoftApi.Models;

namespace NeosoftApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Usuarioos { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Variable> Variables { get; set; }
}