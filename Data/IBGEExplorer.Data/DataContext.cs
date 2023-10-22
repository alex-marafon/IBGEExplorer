using IBGEExplorer.Account.Entities;
using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data;

public class DataContext : DbContext
{
    public DbSet<User> User { get; private set; }
    public DbSet<Role> Role { get; private set; }
    public DbSet<UserRole> UserRole { get; private set; }
    public DbSet<IBGE> City { get; private set; }
    public DbSet<County> County { get; private set; }
    public DbSet<State> State { get; private set; }

    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());       
        modelBuilder.ApplyConfiguration(new RoleMap());       
        modelBuilder.ApplyConfiguration(new UserRoleMap());       
        modelBuilder.ApplyConfiguration(new IBGEMap());       
        modelBuilder.ApplyConfiguration(new CountyMap());       
        modelBuilder.ApplyConfiguration(new StateMap());       
    }
}