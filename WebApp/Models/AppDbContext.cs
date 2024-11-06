using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }

    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source = {DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity
            {
                Id = 1,
                FirstName = "Aleksy",
                LastName = "Malawski",
                Email = "AleksyMalawski@gmail.com",
                PhoneNumber = "12345678",
                BirthDate = new(2003,10,17),
                Created = DateTime.Now,
                    
            },
            new ContactEntity
            {
                Id = 2,
                FirstName = "John",
                LastName = "Malawski",
                Email = "jogn@gmail.com",
                PhoneNumber = "12345678",
                BirthDate = new(1999,10,17),
                Created = DateTime.Now,
                    
            }
            );
    }
}