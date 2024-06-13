using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework;

public class TelegramBotDbContext: DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<CustomField<string>> CustomFields { get; set; }
    
    public TelegramBotDbContext(DbContextOptions<TelegramBotDbContext> options)
        : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PersonConfiguration());

        modelBuilder.ApplyConfiguration(new CustomFieldConfiguration());

    }
}