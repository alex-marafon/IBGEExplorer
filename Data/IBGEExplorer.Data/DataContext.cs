using IBGEExplorer.Core.Contexts.Shared.Entities;
using IBGEExplorer.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data;

public class DataContext : DbContext
{
    public DbSet<Account> Account { get; set; }

    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountMap());       
    }
}