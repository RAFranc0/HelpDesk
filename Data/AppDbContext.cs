using HelpDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<UserModel> Users { get; set; }
    public DbSet<TicketModel>  Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserModel>();
        modelBuilder.Entity<TicketModel>();
    }
}