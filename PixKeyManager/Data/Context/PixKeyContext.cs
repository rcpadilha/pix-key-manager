
using Microsoft.EntityFrameworkCore;
using PixKeyManager.Data.Model;

namespace PixKeyManager.Data.Context;

public class PixKeyContext : DbContext
{
    public PixKeyContext(DbContextOptions<PixKeyContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<Account>()
            .Property(a => a.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        modelBuilder.Entity<Key>()
            .Property(k => k.Id)
            .HasDefaultValueSql("gen_random_uuid()");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Key> Keys { get; set; }
}

