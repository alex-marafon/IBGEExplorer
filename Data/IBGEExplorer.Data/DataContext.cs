using IBGEExplorer.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());       
        modelBuilder.ApplyConfiguration(new RoleMap());       
        modelBuilder.ApplyConfiguration(new UserRoleMap());       
    }
}