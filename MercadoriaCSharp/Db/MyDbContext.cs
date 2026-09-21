using MercadoriaCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace MercadoriaCSharp.Db;

public class MyDbContext : DbContext
{
    public DbSet<Mercadoria> mercadoria{get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server = 127.0.0.1; User Id=root; Password=vertrigo; Database=mercadoria;";
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {}
}